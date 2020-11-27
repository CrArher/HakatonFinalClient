using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;

namespace DefaultNamespace.Recording
{
    public class RecordingController : IController
    {
        private readonly GlobalContext _context;
        private readonly RecordingModel _model;
        private readonly RecordingComponent _component;

        public RecordingController(GlobalContext context, RecordingModel model, RecordingComponent component)
        {
            _context = context;
            _model = model;
            _component = component;
        }

        public void Deactivate()
        {
            _component.Record.onClick.RemoveListener(OnRecord);
        }

        public void Activate()
        {
            _component.Record.onClick.AddListener(OnRecord);
        }



        private async void OnRecord()
        {
            _model.IsRecording = !_model.IsRecording;
            _model.Record();

            if (_model.IsRecording)
            {
                _component.Record.image.color = Color.red;
            }
            else
            {
                var samples = new float[_model.clip.samples];
                _model.clip.GetData(samples, 0);

                var intData = new Int16[samples.Length];

                Byte[] bytesData = new Byte[samples.Length * 2];

                int rescaleFactor = 32767;

                for (int i = 0; i < samples.Length; i++)
                {
                    intData[i] = (short) (samples[i] * rescaleFactor);
                    Byte[] byteArr = new Byte[2];
                    byteArr = BitConverter.GetBytes(intData[i]);
                    byteArr.CopyTo(bytesData, i * 2);
                }

                _component.Record.image.color = Color.white;
                
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://shazam.p.rapidapi.com/songs/detect"),
                    Headers =
                    {
                        { "x-rapidapi-key", "77e1fb6fc3msh93932a198ae203fp1793a3jsn787f1c4ecdbe" },
                        { "x-rapidapi-host", "shazam.p.rapidapi.com" },
                    },
                    
                    Content = new StringContent(Convert.ToBase64String(bytesData))
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/xml")
                        }
                    }
                };
                
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
                
            }
        }
        
    }
}
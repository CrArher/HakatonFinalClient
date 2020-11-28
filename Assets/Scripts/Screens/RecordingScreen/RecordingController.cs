using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Timers;
using UnityEngine;

namespace Screens.RecordingScreen
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
            _component.EndTimer -= OnEndTimer;
        }

        public void Activate()
        {
            _component.Record.onClick.AddListener(OnRecord);
            _component.EndTimer += OnEndTimer;
        }

        private void OnRecord()
        {
            try
            {
                _model.IsRecording = !_model.IsRecording;
                _component.IsRecording = _model.IsRecording;
                Debug.Log(_model.IsRecording);
                if (_model.IsRecording)
                {
                    _model.clip = Microphone.Start(_component.Device, false, 7, 80000);
                    _component.EnableTimer();
                }
                else
                {
                    Microphone.End(_component.Device);
                }

                Debug.Log(_model.IsRecording);

                if (!_model.IsRecording)
                {
                    _component.IsEnableTimer = false;
                    SavWav.Save("TEST", _model.clip, EndFind);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _component.TEXT.text = e.Message;
                throw;
            }
        }

        private void EndFind(string result)
        {
        }

        private void OnEndTimer()
        {
            Debug.Log("END TIMER");
            OnRecord();
        }
    }
}
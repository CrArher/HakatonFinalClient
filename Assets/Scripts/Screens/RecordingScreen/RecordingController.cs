using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Timers;
using Lib.fastJSON;
using Screens.RecordingScreen.Platforms;
using UnityEngine;
using Utilities;

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

        private async void EndFind(string data)
        {
            var json = (Dictionary<string, object>) JSON.Parse(data);
            var resultData = json.GetNode("result");
            
            var label = resultData.GetString("label");
            var title = resultData.GetString("title");
            var album = resultData.GetString("album");
            var artist = resultData.GetString("artist");
            var trackLink = resultData.GetString("song_link");

            Apple apple = null;
            Deezer deezer = null;
            Spotify spotify = null;

            if (resultData.ContainsKey("apple_music"))
            {
                apple = new Apple((Dictionary<string, object>) resultData.GetNode("apple_music"));
                
                apple.Label = label;
                apple.Title = title;
                apple.Album = album;
                apple.Artist = artist;
                apple.TrackLink = trackLink;
                apple.SetImage();
            }

            if (resultData.ContainsKey("deezer"))
            {
                deezer = new Deezer((Dictionary<string, object>) resultData.GetNode("deezer"));
                
                deezer.Label = label;
                deezer.Title = title;
                deezer.Album = album;
                deezer.Artist = artist;
                deezer.TrackLink = trackLink;
                deezer.SetImage();
            }

            if (resultData.ContainsKey("spotify"))
            {
                spotify = new Spotify((Dictionary<string, object>) resultData.GetNode("spotify"));
                
                spotify.Label = label;
                spotify.Title = title;
                spotify.Album = album;
                spotify.Artist = artist;
                spotify.TrackLink = trackLink;
                spotify.SetImage();
            }
        }

        private void OnEndTimer()
        {
            Debug.Log("END TIMER");
            OnRecord();
        }
    }
}
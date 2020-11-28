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
            _model.Hide += OnHide;
            _model.Show += OnShow;
            _component.Record.onClick.AddListener(OnRecord);
            _component.EndTimer += OnEndTimer;
        }

        private void OnShow()
        {
            _component.StartShow = true;
        }

        private void OnHide()
        {
            _component.StartShow = false;
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
                throw;
            }
        }

        private async void EndFind(string data)
        {
            var json = (Dictionary<string, object>) JSON.Parse(data);
            var resultData = json.GetNode("result");

            if (resultData.Count > 1)
            {
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
                    _component.StartCoroutine(apple.GetTexture());
                }

                if (resultData.ContainsKey("deezer"))
                {
                    deezer = new Deezer((Dictionary<string, object>) resultData.GetNode("deezer"));

                    deezer.Label = label;
                    deezer.Title = title;
                    deezer.Album = album;
                    deezer.Artist = artist;
                    deezer.TrackLink = trackLink;
                    _component.StartCoroutine(deezer.GetTexture());
                }

                if (resultData.ContainsKey("spotify"))
                {
                    spotify = new Spotify((Dictionary<string, object>) resultData.GetNode("spotify"));

                    spotify.Label = label;
                    spotify.Title = title;
                    spotify.Album = album;
                    spotify.Artist = artist;
                    spotify.TrackLink = trackLink;
                    _component.StartCoroutine(spotify.GetTexture());
                }

                if (apple != null)
                {
                    _context.MainScreenModel.Album = apple.Album;
                    _context.MainScreenModel.Author = apple.Artist;
                    _context.MainScreenModel.Image = apple.Image;
                    _context.MainScreenModel.Link = apple.TrackLink;
                    _context.MainScreenModel.Title = apple.Title;
                    _context.MainScreenModel.OnFind();
                }
                else if (deezer != null)
                {
                    _context.MainScreenModel.Album = deezer.Album;
                    _context.MainScreenModel.Author = deezer.Artist;
                    _context.MainScreenModel.Image = deezer.Image;
                    _context.MainScreenModel.Link = deezer.TrackLink;
                    _context.MainScreenModel.Title = deezer.Title;
                    _context.MainScreenModel.OnFind();
                }
                else if (spotify != null)
                {
                    _context.MainScreenModel.Album = spotify.Album;
                    _context.MainScreenModel.Author = spotify.Artist;
                    _context.MainScreenModel.Image = spotify.Image;
                    _context.MainScreenModel.Link = spotify.TrackLink;
                    _context.MainScreenModel.Title = spotify.Title;
                    _context.MainScreenModel.OnFind();
                }
            }
        }

        private void OnEndTimer()
        {
            Debug.Log("END TIMER");
            OnRecord();
        }
    }
}
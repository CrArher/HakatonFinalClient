using System;
using UnityEngine;

namespace Screens.RecordingScreen
{
    public class RecordingModel
    {
        public event Action Show;
        public event Action Hide;

        public bool IsRecording;
        public AudioClip clip;

        public void Record()
        {
            if (IsRecording)
            {
            }
            else
            {
            }
        }

        public void OnShowOrHide(bool item)
        {
            if (item)
            {
                Show?.Invoke();    
            }
            else
            {
                Hide?.Invoke();
            }
            
        }
    }
}
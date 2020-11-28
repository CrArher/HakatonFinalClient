using UnityEngine;

namespace Screens.RecordingScreen
{
    public class RecordingModel
    {
        public bool IsRecording;
        public AudioClip clip;

        public void Record()
        {
            
            var device = Microphone.devices[0];
            if (IsRecording)
            {
                clip = Microphone.Start(device,false,3,80000);
            }
            else
            {
                Microphone.End(device);
            }
        }
    }
}
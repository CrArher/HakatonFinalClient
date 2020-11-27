using UnityEngine;

namespace DefaultNamespace.Recording
{
    public class RecordingModel
    {
        public bool IsRecording;
        private AudioClip clip;

        public void Record()
        {
            var device = Microphone.devices[0];
            if (IsRecording)
            {
                clip = Microphone.Start(device,false,1,80000);
            }
            else
            {
                Microphone.End(device);
                Debug.Log(clip.length);
            }
        }
    }
    
}
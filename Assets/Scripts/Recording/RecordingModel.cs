using UnityEngine;

namespace DefaultNamespace.Recording
{
    public class RecordingModel
    {
        public bool IsRecording;
        private AudioClip clip;
        private float[] data = new float[]{};
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
                clip.GetData(data, 0);
                Debug.Log(data);
            }
        }
    }
    
}
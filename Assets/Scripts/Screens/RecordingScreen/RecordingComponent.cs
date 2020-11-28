using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.RecordingScreen
{
    public class RecordingComponent : MonoBehaviour
    {
        private float period = 0.03f;
        private float time;
        private List<bool> _enablers = new List<bool>();
        [NonSerialized] public bool IsRecording = true;
        public List<Image> rounds;

        public void Start()
        {
            foreach (var round in rounds)
            {
                _enablers.Add(new bool());
            }
        }

        public void Update()
        {
            time -= Time.deltaTime;
            
            while (IsRecording && time<=0)
            {
                time = period;
                for (int i = 0; i < 5; i++)
                {
                    var color = rounds[i].color;
                    if (!_enablers[i])
                    {
                        if (color.a>i*0.1f)
                        {
                            color.a -= 0.01f;
                            rounds[i].color = color;
                        }
                        else
                        {
                            _enablers[i] = !_enablers[i];
                        }
                    }
                    else
                    {
                        if (color.a<=1-0.1*(5-i))
                        {
                            color.a += 0.01f;
                            rounds[i].color = color;
                        }
                        else
                        {
                            _enablers[i] = !_enablers[i];
                        }
                    }
                }
            }
        }
    }
}
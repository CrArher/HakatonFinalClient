using System;
using System.Collections;
using System.Collections.Generic;
using Screens.ScreenObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.RecordingScreen
{
    public class RecordingComponent : MonoBehaviour, ISceneContainer
    {
        [NonSerialized] public bool StartShow;
        public GameObject root;

        public Image Monkey;
        
        public Action EndTimer;
        
        public Button Record;

        public string Device;
        private float period = 0.03f;
        private float time;
        
        private float periodTimer = 7f;
        private float timeTimer;
        public bool IsEnableTimer;

        public void EnableTimer()
        {
            timeTimer = periodTimer;
            IsEnableTimer = true;
        }

        private List<bool> _enablers = new List<bool>();
        [NonSerialized] public bool IsRecording = false;
        public List<Image> rounds;
        public void Start()
        {
            Device = Microphone.devices[0];
            foreach (var round in rounds)
            {
                _enablers.Add(new bool());
            }
        }

        public void Update()
        {
            time -= Time.deltaTime;
            timeTimer -= Time.deltaTime;

            if (timeTimer <= 0 && IsEnableTimer)
            {
                timeTimer = periodTimer;
                IsEnableTimer = false;
                EndTimer?.Invoke();
            }
            
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

            if (StartShow)
            {
                if (time <= 0 && root.transform.localPosition.y <0)
                {
                    var pos = root.transform.localPosition;
                    pos.y += 12;
                    root.transform.localPosition = pos;
                }
                if (time <= 0 && Math.Abs(Monkey.transform.eulerAngles.z - (45)) > 5f) 
                {
                    Monkey.transform.Rotate(0,0,3f);
                }
            }
            else
            {
                if (time<=0&& root.transform.localPosition.y > -800-root.GetComponentInParent<RectTransform>().rect.height)
                {
                    var pos = root.transform.localPosition;
                    pos.y -= 12;
                    root.transform.localPosition = pos;
                    
                }

                if (time <= 0 && Math.Abs(Monkey.transform.eulerAngles.z - (225)) > 5f) 
                {
                    Monkey.transform.Rotate(0,0,-3f);
                }
            }
            
            
        }
    }
}
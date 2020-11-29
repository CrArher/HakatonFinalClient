using System;
using Screens.RecordingScreen;
using Screens.ScreenObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.MainScreen
{
    public class MainScreenComponent : MonoBehaviour, ISceneContainer
    {

        public TMP_InputField FindField;
        
        public TextMeshProUGUI DMCa;
        public TextMeshProUGUI Label;
        public RawImage BackGround;
        public RawImage Image;
        public Image DefaultBackground;
        public TextMeshProUGUI author;
        public TextMeshProUGUI title;
        public TextMeshProUGUI album;
        public GameObject Root;
        public TextMeshProUGUI link;


        private float period = 0.02f;
        private float time;
        [NonSerialized] public bool IsRecord;

        public Button RecordScreenButton;

        public void Update()
        {
            time -= Time.deltaTime;
            if (IsRecord)
            {
                if (time <= 0)
                {
                    time = period;
                    if (RecordScreenButton.transform.localScale.x > -1)
                    {
                        
                        var scale = RecordScreenButton.transform.localScale;
                        scale.x -= 0.1f;
                        scale.y -= 0.1f;
                        RecordScreenButton.transform.localScale = scale;
                    }
                    

                }
            }
            else
            {
                if (time <= 0)
                {
                    if (this.GetComponent<RecordingComponent>().root.transform.position.y < -900 &&
                        !FindField.gameObject.activeSelf)
                    {
                        FindField.gameObject.SetActive(true);
                    }

                    time = period;
                    if (RecordScreenButton.transform.localScale.x < 1)
                    {
                        var scale = RecordScreenButton.transform.localScale;
                        scale.x += 0.1f;
                        scale.y += 0.1f;
                        RecordScreenButton.transform.localScale = scale;
                    }
                }
            }
        }
    }
}
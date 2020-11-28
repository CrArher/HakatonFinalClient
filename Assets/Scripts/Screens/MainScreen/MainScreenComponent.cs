﻿using System;
using Screens.RecordingScreen;
using Screens.ScreenObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.MainScreen
{
    public class MainScreenComponent : MonoBehaviour, ISceneContainer
    {
        public GameObject SearchesHistoryRoot;
        public GameObject FreePlayLists;

        public TMP_InputField FindField;

        public RawImage BackGround;
        public RawImage Image;
        public Image DefaultBackground;
        public TextMeshProUGUI author;
        public TextMeshProUGUI title;
        public TextMeshProUGUI album;
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
                        !SearchesHistoryRoot.gameObject.activeSelf && !FreePlayLists.gameObject.activeSelf &&
                        !FindField.gameObject.activeSelf)
                    {
                        SearchesHistoryRoot.gameObject.SetActive(true);
                        FreePlayLists.gameObject.SetActive(true);
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
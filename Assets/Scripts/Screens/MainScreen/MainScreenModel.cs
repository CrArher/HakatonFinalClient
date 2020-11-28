using System;
using UnityEngine;

namespace Screens.MainScreen
{
    public class MainScreenModel
    {
        public event Action Find;

        public Texture2D Image;
        public string Title;
        public string Author;
        public string Album;
        public string Link;

        public void OnFind()
        {
            Find?.Invoke();
        }
    }
}
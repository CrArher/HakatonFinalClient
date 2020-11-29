using System;
using System.Collections.Generic;
using UnityEngine;

namespace Screens.MainScreen
{
    public class MainScreenModel
    {

        public event Action Search; 
        public List<string> Searches = new List<string>();
        
        public event Action Find;

        public Texture2D Image;
        public string Title;
        public string Author;
        public string Album;
        public string Link;
        public string Label;

        public void OnFind()
        {
            Find?.Invoke();
        }

        public void OnSearch()
        {
            Search?.Invoke();
        }
    }
}
using System;
using UnityEngine;

namespace ScreenManager
{
    [Serializable]
    public class ScreenComponent 
    {
        public ScreenType Type;
        public GameObject Root;
    }
}
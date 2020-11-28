using System;

namespace Screens.ScreenChanger
{
    public class ScreenChangerUnitModel
    {
        public event Action Showed;
        public event Action Hided;
        
        public void Show()
        {
            Showed?.Invoke();
        }

        public void Hide()
        {
            Hided?.Invoke();
        }
    }
}
using System;

namespace ScreenManager.ScreenChanger
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
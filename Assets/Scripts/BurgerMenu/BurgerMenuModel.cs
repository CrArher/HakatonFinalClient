using System;

namespace BurgerMenu
{
    public class BurgerMenuModel
    {
        public event Action Hide;

        public void OnHide()
        {
            Hide?.Invoke();
        }
    }
}
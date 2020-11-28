using System;
using System.Collections.Generic;
using ScreenManager;

namespace Screens.ScreenChanger
{
    public class ScreenChangerModel
    {
        public event Action ChangedScreen;
        public ScreenType CurrentScreen;

        public Dictionary<ScreenType, ScreenChangerUnitModel> UnitModels =new Dictionary<ScreenType, ScreenChangerUnitModel>();

        public ScreenChangerModel(ScreenType currentScreen)
        {
            CurrentScreen = currentScreen;

            foreach (var screen in GetScreen())
            {
                UnitModels.Add(screen, new ScreenChangerUnitModel());
            }
        }

        public void SwitchScreen(ScreenType screen)
        {
            if (CurrentScreen != screen)
            {
                UnitModels[CurrentScreen].Hide();
                UnitModels[screen].Show();
                CurrentScreen = screen;
                ChangedScreen?.Invoke();
            }
        }

        private IEnumerable<ScreenType> GetScreen()
        {
            yield return ScreenType.MainScreen;
            yield return ScreenType.Recording;
            yield return ScreenType.Registration;
            yield return ScreenType.SignIn;
        }
    }
}
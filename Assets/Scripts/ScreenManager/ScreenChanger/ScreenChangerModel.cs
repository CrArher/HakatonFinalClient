using System;
using System.Collections.Generic;

namespace ScreenManager.ScreenChanger
{
    public class ScreenChangerModel
    {
        public event Action ChangedScreen;
        public ScreenType CurrentScreen;

        public Dictionary<ScreenType, ScreenChangerUnitModel> UnitModels =
            new Dictionary<ScreenType, ScreenChangerUnitModel>();

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
            yield return ScreenType.LeaderPricing;
            yield return ScreenType.LeaderSignUp;
            yield return ScreenType.LeaderNewGame;
            yield return ScreenType.LeaderGame;
            yield return ScreenType.PlayerEnter;
            yield return ScreenType.StartScreen;
            yield return ScreenType.InfoScreen;
            yield return ScreenType.LeaderSignIn;
            yield return ScreenType.Admin;
            yield return ScreenType.PlayerGame;
            yield return ScreenType.LoadScreen;
        }
    }
}
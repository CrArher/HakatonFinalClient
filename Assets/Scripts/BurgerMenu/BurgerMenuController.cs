using ScreenManager;

namespace BurgerMenu
{
    public class BurgerMenuController : IController
    {
        private readonly GlobalContext _context;
        private readonly BurgerMenuModel _model;
        private readonly BurgerMenuComponent _component;

        public BurgerMenuController(GlobalContext context,BurgerMenuModel model,BurgerMenuComponent component)
        {
            _context = context;
            _model = model;
            _component = component;
        }
        public void Deactivate()
        {
            _context.ScreenChangerModel.ChangedScreen -= OnChangedScreen;
        }

        public void Activate()
        {
            _context.ScreenChangerModel.ChangedScreen += OnChangedScreen;
        }

        private void OnChangedScreen()
        {
            if (_context.ScreenChangerModel.CurrentScreen != ScreenType.SignIn && _context.ScreenChangerModel.CurrentScreen != ScreenType.Registration)
            {
                _component.gameObject.SetActive(false);
            }
        }
    }
}
using ScreenManager;

namespace Screens.Registration
{
    public class RegistrationController : IController
    {
        private readonly GlobalContext _context;
        private readonly RegistrationComponent _container;

        public RegistrationController(GlobalContext context, RegistrationComponent container)
        {
            _context = context;
            _container = container;
        }

        public void Deactivate()
        {
            _container.SignInButton.onClick.RemoveListener(OnClickSignIn);
        }

        public void Activate()
        {
            _container.SignInButton.onClick.AddListener(OnClickSignIn);
        }

        private void OnClickSignIn()
        {
            _context.ScreenChangerModel.SwitchScreen(ScreenType.SignIn);
        }
    }
}
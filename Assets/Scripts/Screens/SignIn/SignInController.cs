using ScreenManager;

namespace Screens.SignIn
{
    public class SignInController : IController
    {
        private readonly GlobalContext _context;
        private readonly SignInComponent _component;

        public SignInController(GlobalContext context, SignInComponent component)
        {
            _context = context;
            _component = component;
        }
        
        public void Deactivate()
        {
            _component.RegistrationButton.onClick.RemoveListener(OnClickRegister);
            _component.EnterButton.onClick.RemoveListener(OnClickEnter);  
        }

        public void Activate()
        {
            _component.RegistrationButton.onClick.AddListener(OnClickRegister);
            _component.EnterButton.onClick.AddListener(OnClickEnter);
        }

        private void OnClickEnter()
        {
            
        }

        private void OnClickRegister()
        {
            _context.ScreenChangerModel.SwitchScreen(ScreenType.Registration);
        }
    }
}
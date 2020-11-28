using Commands.SignIn_SignOut;
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
            if (string.IsNullOrEmpty(_component.EmailField.text) || string.IsNullOrEmpty(_component.PasswordField.text))
            {
                _component.WarnRoot.SetActive(true);
            }
            else
            {
                _context.CommandModel.AddCommand(new UserSignInCommand(_component.EmailField.text, _component.PasswordField.text, Callback));
            }
        }

        private void OnClickRegister()
        {
            _context.ScreenChangerModel.SwitchScreen(ScreenType.Registration);
            
            
        }

        private void Callback(bool value)
        {
            if (value)
            {
                _context.ScreenChangerModel.SwitchScreen(ScreenType.MainScreen);
            }
            else
            {
                _component.WarnRoot.SetActive(true);
            }
        }
    }
}
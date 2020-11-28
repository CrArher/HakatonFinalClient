using Commands.Registration;
using ScreenManager;
using UnityEngine;

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
            _container.Registration.onClick.RemoveListener(OnClickRegistration);
        }

        public void Activate()
        {
            _container.SignInButton.onClick.AddListener(OnClickSignIn);
            _container.Registration.onClick.AddListener(OnClickRegistration);
        }

        private void OnClickRegistration()
        {
            _context.CommandModel.AddCommand(new RegistrationCommand(_container.LoginField.text, _container.EmailField.text,
                _container.PasswordField.text, OnRegistrationCallback));
        }

        private void OnRegistrationCallback(bool value)
        {
            if (value)
            {
                _context.ScreenChangerModel.SwitchScreen(ScreenType.MainScreen);
            }
            else
            {
            }
        }

        private void OnClickSignIn()
        {
            _context.ScreenChangerModel.SwitchScreen(ScreenType.SignIn);
        }
    }
}
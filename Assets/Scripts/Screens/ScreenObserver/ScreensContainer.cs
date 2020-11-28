using Screens.MainScreen;
using Screens.RecordingScreen;
using Screens.Registration;
using Screens.SignIn;
using UnityEngine;

namespace Screens.ScreenObserver
{
    public class ScreensContainer : MonoBehaviour
    {
        public SignInComponent SignInComponent;
        public RegistrationComponent RegistrationComponent;
        public MainScreenComponent MainScreenComponent;
        public RecordingComponent RecordingComponent;
    }
}
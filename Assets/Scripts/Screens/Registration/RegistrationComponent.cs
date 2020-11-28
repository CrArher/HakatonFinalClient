using Screens.ScreenObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Registration
{
    public class RegistrationComponent : MonoBehaviour, ISceneContainer
    {
        public Button SignInButton;
        public Button Registration;
        public TMP_InputField LoginField;
        public TMP_InputField EmailField;
        public TMP_InputField PasswordField;
    }
}
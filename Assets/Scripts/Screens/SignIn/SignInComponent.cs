using Screens.ScreenObserver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.SignIn
{
    public class SignInComponent : MonoBehaviour, ISceneContainer
    {
        public Button EnterButton;
        public Button RegistrationButton;
        public TMP_InputField EmailField;
        public TMP_InputField PasswordField;
        public GameObject WarnRoot;
    }
}
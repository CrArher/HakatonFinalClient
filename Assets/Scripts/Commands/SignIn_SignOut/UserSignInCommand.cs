using Commands.Base;
using ScreenManager;
using UnityEngine;
using UnityEngine.Android;
using Utilities;

namespace Commands.SignIn_SignOut
{
    public class UserSignInCommand : ExecuteCommand
    {
        public UserSignInCommand(string email, string password) : base(nameof(UserSignInCommand))
        {
            UserParams.Add("email", email);
            UserParams.Add("password", password);
        }

        public override void Execute(GlobalContext context)
        {
            base.Execute(context);
            context.Mono.StartCoroutine(Send());
        }

        protected override void CallBack()
        {
            var error = Recieve.GetBool("error");
            if (error)
            {
                Debug.Log(Recieve.GetString("error_text"));
            }
            else
            {
                // Context.UserModel.Permission = Recieve.GetString("permission");
                PlayerPrefs.SetString("session", Recieve.GetString("session"));
                PlayerPrefs.SetString("userId", Recieve.GetString("userId"));
                Context.User.IsAuthorization = true;
                Context.User.Id = PlayerPrefs.GetString("userId");
                Context.ScreenChangerModel.SwitchScreen(ScreenType.MainScreen);               
            }
        }
    }
}
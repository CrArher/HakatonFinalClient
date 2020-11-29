using System;
using Commands.Base;
using ScreenManager;
using UnityEngine;
using Utilities;

namespace Commands.SignIn_SignOut
{
    public class UserSignInCommand : ExecuteCommand
    {
        private readonly string _email;
        private readonly Action<bool> _callback;

        public UserSignInCommand(string email, string password, Action<bool> callback) : base(nameof(UserSignInCommand))
        {
            _email = email;
            _callback = callback;
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
                _callback?.Invoke(false);
            }
            else
            {
                Context.User.IsAuthorization = true;
                Context.User.Id = _email;
                PlayerPrefs.SetString("userId", _email);
                Context.ScreenChangerModel.SwitchScreen(ScreenType.MainScreen);
                _callback?.Invoke(true);
            }
        }
    }
}
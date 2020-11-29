using System;
using Commands.Base;
using ScreenManager;
using UnityEngine;
using Utilities;

namespace Commands.Registration
{
    public class RegistrationCommand : ExecuteCommand
    {
        private readonly string _email;
        private readonly Action<bool> _callback;

        public RegistrationCommand(string login,string email, string password, Action<bool> callback) : base(nameof(RegistrationCommand))
        {
            _email = email;
            _callback = callback;
            UserParams.Add("login",login);
            UserParams.Add("email",email );
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
                Debug.LogError(Recieve.GetString("error_text"));
                _callback?.Invoke(false);
            }
            else
            {
                Context.User.IsAuthorization = true;
                PlayerPrefs.SetString("userId", _email);
                Context.User.Id = _email;
                _callback?.Invoke(true);
            }
        }
    }
}
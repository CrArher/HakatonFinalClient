using System;
using Commands.Base;
using DefaultNamespace;
using ScreenManager;
using UnityEngine;
using Utilities;

namespace Commands.SignIn_SignOut
{
    public class SignOutCommand : ExecuteCommand
    {
        public SignOutCommand() : base(nameof(SignOutCommand))
        {
            
            UserParams.Add("userId", PlayerPrefs.GetString("userId"));
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
                if (!Recieve.GetBool("authorisation"))
                {
                    PlayerPrefs.SetString("session", string.Empty);
                    PlayerPrefs.SetString("userId", string.Empty);
                    // Context.UserModel.IsAuthorization = false;
                    // Context.UserModel.Id = PlayerPrefs.GetString("userId");
                    // Context.UserModel.IsLeader = false;
                    // Context.ScreenChangerModel.SwitchScreen(ScreenType.StartScreen);   
                }
            }
        }
    }
}
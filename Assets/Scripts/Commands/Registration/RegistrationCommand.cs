using Commands.Base;
using ScreenManager;
using UnityEngine;
using Utilities;

namespace Commands.Registration
{
    public class RegistrationCommand : ExecuteCommand
    {
        public RegistrationCommand(string firstName,string secondName,string email, string password) : base(nameof(RegistrationCommand))
        {
            UserParams.Add("name",firstName);
            UserParams.Add("secondName",secondName);
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
            }
            else
            {
                PlayerPrefs.SetString("session", Recieve.GetString("session"));
                PlayerPrefs.SetString("userId",  Recieve.GetString("userId"));
                
            }
        }
    }
}
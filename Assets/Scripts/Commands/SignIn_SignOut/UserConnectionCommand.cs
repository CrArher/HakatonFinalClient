using Commands.Base;
using UnityEngine;
using Utilities;

namespace Commands.SignIn_SignOut
{
    public class UserConnectionCommand : ExecuteCommand
    {
        private readonly string _userId;

        public UserConnectionCommand(string userId) : base(nameof(UserConnectionCommand))
        {
            _userId = userId;
            UserParams.Add("user_id",_userId);
        }
        
        public override void Execute(GlobalContext context)
        {
            base.Execute(context);
            context.Mono.StartCoroutine(Send());
        }

        protected override void CallBack()
        {
            Context.User.IsAuthorization = true;
            Context.User.Id = PlayerPrefs.GetString("userId");
            var user = Recieve.GetNode("user");
        }
    }
}
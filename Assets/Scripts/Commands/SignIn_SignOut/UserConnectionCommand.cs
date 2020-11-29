using System.Collections.Generic;
using Commands.Base;
using Lib.fastJSON;
using ScreenManager;
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
            if (!Recieve.GetBool("authorisation"))
            {
                Context.User.IsAuthorization = false;
                Context.User.Id = PlayerPrefs.GetString("userId");
                Context.ScreenChangerModel.SwitchScreen(ScreenType.SignIn);   
            }
            else
            {
                Context.User.IsAuthorization = true;
                Context.User.Id = PlayerPrefs.GetString("userId");
                var user = Recieve.GetNode("user");
                var data = (List<object>)JSON.Parse(Recieve.GetString("history"));
                foreach (var item in data)
                {
                    var subData = (Dictionary<string,object>)JSON.Parse(item.ToString());
                    Debug.Log(subData);
                }
                Context.User.Login = user.GetString("id");
            }
        }
    }
}
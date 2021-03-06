﻿using Commands.Base;

namespace Commands.Registration
{
    public class AddTrackToHistoryCommand : ExecuteCommand
    {
        public AddTrackToHistoryCommand(string track) : base(nameof(AddTrackToHistoryCommand))
        {
            UserParams.Add("track", track);
        }

        public override void Execute(GlobalContext context)
        {
            UserParams.Add("user_id", context.User.Id);
            base.Execute(context);
            context.Mono.StartCoroutine(Send());
        }

        protected override void CallBack()
        {
        }
    }
}
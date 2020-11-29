using Commands.Base;
using UnityEngine;
using Utilities;

namespace Commands
{
    public class GetYouTubeVideoInfoCommand : ExecuteCommand
    {
        private readonly string _link;

        public GetYouTubeVideoInfoCommand(string link) : base(nameof(GetYouTubeVideoInfoCommand))
        {
            _link = link;
        }

        public override void Execute(GlobalContext context)
        {
            base.Execute(context);
            UserParams.Add("link",_link);
            context.Mono.StartCoroutine(Send());
        }

        protected override void CallBack()
        {
            Context.RecordingModel.OnYouTube(Recieve.GetString("callback"));
        }
    }
}
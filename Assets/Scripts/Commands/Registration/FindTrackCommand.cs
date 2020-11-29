using Commands.Base;
using UnityEngine;
using Utilities;

namespace Commands.Registration
{
    public class FindTrackCommand : ExecuteCommand
    {
        public FindTrackCommand(string text) : base(nameof(FindTrackCommand))
        {
            UserParams.Add("text", text);
        }

        public override void Execute(GlobalContext context)
        {
            base.Execute(context);
            context.Mono.StartCoroutine(Send());
        }
        
        protected override void CallBack()
        {
            var datas = Recieve.GetArrayObject("data");
            Context.MainScreenModel.Searches.Clear();
            foreach (string data in datas)
            {
                Context.MainScreenModel.Searches.Add(data);
            }
            Context.MainScreenModel.OnSearch();
            Debug.Log(datas.Count);
        }
    }
}
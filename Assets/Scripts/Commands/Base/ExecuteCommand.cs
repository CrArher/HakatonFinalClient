using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Lib.fastJSON;
using UnityEngine;

namespace Commands.Base
{
    public abstract class ExecuteCommand : IExecuteCommand
    {
        protected GlobalContext Context;
        protected Dictionary<string, object> Recieve = new Dictionary<string, object>();
        public string NameCommand { get; }
        protected Dictionary<string, string> UserParams = new Dictionary<string, string>();
        private WWW _getData;

        protected ExecuteCommand(string nameCommand)
        {
            NameCommand = nameCommand;
            UserParams.Add("Command", nameCommand);
        }

        protected IEnumerator Send()
        {
            var form = new WWWForm();
            foreach (var param in UserParams)
            {
                form.AddField(param.Key, param.Value);
            }
            
            _getData = new WWW("http://25.57.84.220:8000/game_request", form);

            yield return _getData;
            if (_getData.error != null)
            { 
                Debug.Log(_getData.error);
            }

            yield return _getData.text;
            if (_getData.isDone)
            {
                Recieve = (Dictionary<string, object>) JSON.Parse(_getData.text);
            }
            CallBack();
        }

        public virtual void Execute(GlobalContext context)
        {
            Context = context;
            Debug.Log(NameCommand);
        }

        
        protected abstract void CallBack();
    }
}
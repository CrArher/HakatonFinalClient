using Commands;
using ScreenManager.ScreenChanger;
using ScreenObserver;
using UnityEngine;

namespace DefaultNamespace
{
    public class GlobalContext : IGlobalContext
    {
        public GlobalContext()
        {
            
        }

        public GlobalContext(IGlobalContext context)
        {
            CommandModel = context.CommandModel;
            Mono = context.Mono;
        }

        public MonoBehaviour Mono { get; set; }
        public CommandModel CommandModel { get; set; }
        public ScreenChangerModel ScreenChangerModel { get; set; }
    }
}
using Commands;
using UnityEngine;

namespace ScreenObserver
{
    public interface IGlobalContext
    {
        MonoBehaviour Mono { get; set; } 
        CommandModel CommandModel { get; set; }

    }
}
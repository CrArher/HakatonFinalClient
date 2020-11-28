using Commands;
using UnityEngine;

public interface IGlobalContext
{
    MonoBehaviour Mono { get; set; } 
    CommandModel CommandModel { get; set; }
    UserModel User { get; set; }

}
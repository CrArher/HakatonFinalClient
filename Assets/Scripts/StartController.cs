using Commands;
using Screens.ScreenChanger;
using UnityEngine;

public class StartController : MonoBehaviour
{
    private ControllerCollection _controllerCollection = new ControllerCollection();
    private GlobalContext _context = new GlobalContext();
    public GlobalContainer GlobalContainer;
    
    private void Awake()
    {
        _context.Mono = this;
        new CommandGenerator().Generate(_context, _controllerCollection, GlobalContainer);
        new ScreenChangerGenerator().Generate(_context, _controllerCollection, GlobalContainer);
        
        _controllerCollection.Activate();
    }
}

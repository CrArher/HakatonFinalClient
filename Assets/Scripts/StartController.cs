using BurgerMenu;
using Commands;
using Commands.SignIn_SignOut;
using ScreenManager;
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
        new BurgerMenuGenerator().Generate(_context,_controllerCollection,GlobalContainer);

        _controllerCollection.Activate();

        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("userId")))
        {
            _context.CommandModel.AddCommand(new UserConnectionCommand(PlayerPrefs.GetString("userId")));
            _context.ScreenChangerModel.SwitchScreen(ScreenType.MainScreen);
        }
    }
}

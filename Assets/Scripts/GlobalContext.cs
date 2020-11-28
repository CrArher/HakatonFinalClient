using BurgerMenu;
using Commands;
using Screens.MainScreen;

using Screens.RecordingScreen;
using Screens.ScreenChanger;
using UnityEngine;

public class GlobalContext : IGlobalContext
{
    public GlobalContext()
    {
        User = new UserModel();
    }

    public GlobalContext(IGlobalContext context)
    {
        CommandModel = context.CommandModel;
        Mono = context.Mono;
        User = context.User;
    }

    public MonoBehaviour Mono { get; set; }
    public CommandModel CommandModel { get; set; }
    public ScreenChangerModel ScreenChangerModel { get; set; }
    public UserModel User { get; set; }

    public RecordingModel RecordingModel { get; set; }
    public MainScreenModel MainScreenModel { get; set; }
    public BurgerMenuModel BurgerMenuModel { get; set; }
}
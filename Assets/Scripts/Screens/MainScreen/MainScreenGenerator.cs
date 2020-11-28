using Screens.ScreenObserver;

namespace Screens.MainScreen
{
    public class MainScreenGenerator: IScreenGenerator<GlobalContext,MainScreenComponent>
    {
        public void Generate(GlobalContext context, MainScreenComponent container, ControllerCollection collection)
        {
            var controller = new MainScreenController(context, container);
            collection.Add(controller);
        }
    }
}
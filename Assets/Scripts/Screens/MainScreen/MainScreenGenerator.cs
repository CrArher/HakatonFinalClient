
using Screens.ScreenObserver;

namespace Screens.MainScreen
{
    public class MainScreenGenerator: IScreenGenerator<GlobalContext,MainScreenComponent>
    {
        public void Generate(GlobalContext context, MainScreenComponent container, ControllerCollection collection)
        {
            var model = new MainScreenModel();
            context.MainScreenModel = model;
            var controller = new MainScreenController(context,model, container);
            collection.Add(controller);
            
        }
    }
}
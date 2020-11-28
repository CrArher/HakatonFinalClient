using ScreenManager;

namespace Screens.ScreenChanger
{
    public class ScreenChangerGenerator : IGenerator
    {
        public void Generate(GlobalContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new ScreenChangerModel(ScreenType.SignIn);
            context.ScreenChangerModel = model;
            var controller = new ScreenChangerController(context, model, container.Screens);
            var ScreenObserver = new ScreenObserver.ScreenObserver(context, model, container.ScreensContainer);
            controllerCollection.Add(ScreenObserver);
            controllerCollection.Add(controller);
        }
    }
}
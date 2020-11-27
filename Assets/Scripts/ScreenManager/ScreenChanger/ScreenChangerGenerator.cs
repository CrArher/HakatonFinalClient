using DefaultNamespace;

namespace ScreenManager.ScreenChanger
{
    public class ScreenChangerGenerator : IGenerator
    {
        public void Generate(GlobalContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new ScreenChangerModel(ScreenType.StartScreen);
            context.ScreenChangerModel = model;
            var controller = new ScreenChangerController(context,model,container.Screens);
            controllerCollection.Add(controller);
        }
    }
}
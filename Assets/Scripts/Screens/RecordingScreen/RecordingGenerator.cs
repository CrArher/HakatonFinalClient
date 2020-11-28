using Screens.ScreenObserver;

namespace Screens.RecordingScreen
{
    public class RecordingGenerator : IScreenGenerator<GlobalContext,RecordingComponent>
    {
        public void Generate(GlobalContext context, RecordingComponent container, ControllerCollection collection)
        {var model = new RecordingModel();
            context.RecordingModel = model;
            var controller = new RecordingController(context,model,container);
            collection.Add(controller);
        }
    }
}
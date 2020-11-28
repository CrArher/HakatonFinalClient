using Screens.ScreenObserver;

namespace Screens.Registration
{
    public class RegistrationGenerator : IScreenGenerator<GlobalContext, RegistrationComponent>
    {
        public void Generate(GlobalContext context, RegistrationComponent container, ControllerCollection collection)
        {
            var controller = new RegistrationController(context, container);
            collection.Add(controller);
        }
    }
}
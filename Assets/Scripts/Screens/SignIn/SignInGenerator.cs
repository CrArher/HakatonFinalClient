using Screens.ScreenObserver;
using UnityEngine;

namespace Screens.SignIn
{
    public class SignInGenerator : IScreenGenerator<GlobalContext,SignInComponent>
    {
        public void Generate(GlobalContext context, SignInComponent container, ControllerCollection collection)
        {
            var controller = new SignInController(context, container);
            collection.Add(controller);
        }
    }
}
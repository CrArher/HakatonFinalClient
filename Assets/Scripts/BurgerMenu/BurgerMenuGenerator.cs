namespace BurgerMenu
{
    public class BurgerMenuGenerator : IGenerator
    {
        public void Generate(GlobalContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new BurgerMenuModel();
            context.BurgerMenuModel = model;
            var controller = new BurgerMenuController(context,model,container.BurgerMenuComponent);
            controllerCollection.Add(controller);
        }
    }
}
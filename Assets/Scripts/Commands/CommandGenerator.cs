namespace Commands
{
    public class CommandGenerator : IGenerator
    {
        public void Generate(GlobalContext context, ControllerCollection controllerCollection, GlobalContainer container)
        {
            var model = new CommandModel();
            context.CommandModel = model;
            var controller = new CommandController(context,model);
            controllerCollection.Add(controller);
        }
    }
}
using Commands.Base;

namespace Commands
{
    public class CommandController : IController
    {
        private readonly GlobalContext _context;
        private readonly CommandModel _model;

        public CommandController(GlobalContext context, CommandModel model)
        {
            _context = context;
            _model = model;
        }

        public void Activate()
        {
            _model.Add += OnAdd;
        }

        public void Deactivate()
        {
            _model.Add -= OnAdd;
        }

        private void OnAdd(IExecuteCommand command)
        {
            command.Execute(_context);
        }
    }
}
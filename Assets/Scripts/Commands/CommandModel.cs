using System;
using Commands.Base;

namespace Commands
{
    public class CommandModel
    {
        public event Action<IExecuteCommand> Add;

        public void AddCommand(IExecuteCommand command)
        {
            Add?.Invoke(command);
        }
    }
}
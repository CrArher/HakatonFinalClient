
namespace Commands.Base
{
    public interface IExecuteCommand : ICommand
    { 
        void Execute(GlobalContext context);
    }
}
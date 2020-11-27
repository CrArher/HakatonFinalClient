
using DefaultNamespace;

public interface IGenerator
{
    void Generate(GlobalContext context, ControllerCollection controllerCollection, GlobalContainer container);
}
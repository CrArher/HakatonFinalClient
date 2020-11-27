using DefaultNamespace;

namespace ScreenObserver
{
    public interface IScreenGenerator<TContext, TScreenContainer> where TContext : IGlobalContext
        where TScreenContainer : ISceneContainer
    {
        void Generate(TContext context, TScreenContainer container, ControllerCollection collection);
    }
}
namespace Screens.ScreenObserver
{
    public interface IScreenGenerator<in TContext, in TScreenContainer> where TContext : IGlobalContext where TScreenContainer : ISceneContainer
    {
        void Generate(TContext context, TScreenContainer container, ControllerCollection collection);
    }
}
namespace Screens.ScreenChanger
{
    public class ScreenChangerController : IController
    {
        private readonly GlobalContext _context;
        private readonly ScreenChangerModel _model;
        private readonly ScreenManager.Screens _screens;
        private readonly ControllerCollection _controllers = new ControllerCollection();

        public ScreenChangerController(GlobalContext context, ScreenChangerModel model, ScreenManager.Screens screens)
        {
            _context = context;
            _model = model;
            _screens = screens;
        }

        public void Deactivate()
        {
            _controllers.Deactivate();
            _controllers.Clear();
        }

        public void Activate()
        {
            foreach (var unitModel in _model.UnitModels)
            {
                var component = _screens[unitModel.Key];
                var controller = new ScreenChangerUnitController(_context, unitModel.Value, component);
                _controllers.Add(controller);
            }

            _controllers.Activate();
            _model.UnitModels[_model.CurrentScreen].Show();
        }
    }
}
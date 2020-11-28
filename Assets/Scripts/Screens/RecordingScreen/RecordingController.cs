namespace Screens.RecordingScreen
{
    public class RecordingController : IController

    {
        private readonly GlobalContext _context;
        private readonly RecordingModel _model;
        private readonly RecordingComponent _component;

        public RecordingController(GlobalContext context,RecordingModel model,RecordingComponent component)
        {
            _context = context;
            _model = model;
            _component = component;
        }
        public void Deactivate()
        {
            
        }

        public void Activate()
        {
        }
    }
}
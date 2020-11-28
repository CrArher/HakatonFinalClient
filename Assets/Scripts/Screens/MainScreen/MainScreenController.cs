namespace Screens.MainScreen
{
    public class MainScreenController : IController
    {
        private readonly GlobalContext _context;
        private readonly MainScreenComponent _component;

        public MainScreenController(GlobalContext context, MainScreenComponent component)
        {
            _context = context;
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
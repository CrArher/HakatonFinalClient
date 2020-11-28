using ScreenManager;

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
            _component.RecordScreenButton.onClick.RemoveListener(OnClickRecordScreen);
        }

        public void Activate()
        {
            _component.RecordScreenButton.onClick.AddListener(OnClickRecordScreen);
        }

        private void OnClickRecordScreen()
        {
            _context.ScreenChangerModel.SwitchScreen(ScreenType.Recording);
        }
    }
}
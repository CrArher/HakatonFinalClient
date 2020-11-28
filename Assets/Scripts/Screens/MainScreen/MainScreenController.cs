using ScreenManager;

namespace Screens.MainScreen
{
    public class MainScreenController : IController
    {
        private readonly GlobalContext _context;
        private readonly MainScreenModel _model;
        private readonly MainScreenComponent _component;

        public MainScreenController(GlobalContext context,MainScreenModel model, MainScreenComponent component)
        {
            _context = context;
            _model = model;
            _component = component;
        }
        
        public void Deactivate()
        {
            _component.RecordScreenButton.onClick.RemoveListener(OnClickRecordScreen);
            _model.Find -= OnFind;
        }

        public void Activate()
        {
            _component.RecordScreenButton.onClick.AddListener(OnClickRecordScreen);
            _model.Find += OnFind;
        }

        private void OnFind()
        {
            var color = _component.DefaultBackground.color;
            color.a -= 0.2f;
            _component.DefaultBackground.color = color;
            OnClickRecordScreen();

            _component.Image.texture = _model.Image;
            _component.BackGround.texture = _model.Image;
            _component.author.text = _model.Author;
            _component.album.text = _model.Album;
            _component.link.text = _model.Link;
            _component.title.text = _model.Title;

            _component.BackGround.gameObject.SetActive(true);
            _component.Image.gameObject.SetActive(true);
        }

        private void OnClickRecordScreen()
        {
            _component.IsRecord = !_component.IsRecord;
            _context.RecordingModel.OnShowOrHide(_component.IsRecord);
        }
    }
}
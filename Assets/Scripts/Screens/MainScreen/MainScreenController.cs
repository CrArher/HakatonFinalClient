using Commands;
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
            _component.FindField.onSubmit.RemoveListener(OnSubmitFind);
            _model.Find -= OnFind;
        }

        public void Activate()
        {
            _component.RecordScreenButton.onClick.AddListener(OnClickRecordScreen);
            _component.FindField.onSubmit.AddListener(OnSubmitFind);
            _model.Find += OnFind;
        }

        private void OnSubmitFind(string arg0)
        {
            _context.CommandModel.AddCommand(new GetYouTubeVideoInfoCommand(arg0));
        }

        private void OnFind()
        {
            var color = _component.DefaultBackground.color;
            color.a = 0.9f;
            _component.DefaultBackground.color = color;
            OnClickRecordScreen();


            _component.Image.texture = _model.Image;
            _component.BackGround.texture = _model.Image;
            _component.author.text = _model.Author;
            _component.album.text = _model.Album;
            _component.link.text = _model.Link;
            _component.title.text = _model.Title;

            _component.author.gameObject.SetActive(true);
            _component.album.gameObject.SetActive(true);
            _component.link.gameObject.SetActive(true);
            _component.title.gameObject.SetActive(true);
            _component.BackGround.gameObject.SetActive(true);
            _component.Image.gameObject.SetActive(true);
        }

        private void OnClickRecordScreen()
        {
            _component.IsRecord = !_component.IsRecord;
            _context.RecordingModel.OnShowOrHide(_component.IsRecord);
            if (_component.IsRecord)
            {
                _context.BurgerMenuModel.OnHide();
                _component.FindField.gameObject.SetActive(false);
            }
            else
            {
            //     _component.SearchesHistoryRoot.gameObject.SetActive(true);
            //     _component.FreePlayLists.gameObject.SetActive(true);
            }
        }
    }
}
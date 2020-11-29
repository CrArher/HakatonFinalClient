using Commands;
using Commands.Registration;
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
            _component.FindField.onValueChanged.RemoveListener(OnSubmitFind);
            _component.Yo.onClick.RemoveListener(OnSubmitYo);
            _model.Find -= OnFind;
        }

        public void Activate()
        {
            _component.RecordScreenButton.onClick.AddListener(OnClickRecordScreen);
            _component.FindField.onValueChanged.AddListener(OnSubmitFind);
            _component.Yo.onClick.AddListener(OnSubmitYo);
            _model.Find += OnFind;
            _model.Search += OnSearch;
        }

        private void OnSearch()
        {
            _component.Clear();
            if (_model.Searches.Count == 0)
            {
                _component.root.SetActive(false);
            }
            else
            {
                _component.root.SetActive(true);
            }
            foreach (var search in _model.Searches)
            {
                var component = _component.CreateSearchedTreck();
                component.text = search;
            }
        }

        private void OnSubmitFind(string arg0)
        {
            if (arg0.Contains("youtube.com") || arg0.Contains("youtu.be"))
            {
                _component.RootYo.SetActive(true);
            }
            else
            {
                _context.CommandModel.AddCommand(new FindTrackCommand(arg0));
                _component.RootYo.SetActive(false);
            }
        }

        private void OnSubmitYo()
        {
            _context.CommandModel.AddCommand(new GetYouTubeVideoInfoCommand(_component.FindField.text));
            _component.FindField.text = "";
        }

        private void OnFind()
        {
            var color = _component.DefaultBackground.color;
            color.a = 0.9f;
            _component.DefaultBackground.color = color;
            _context.RecordingModel.OnShowOrHide(false);
            _component.Image.texture = _model.Image;
            _component.BackGround.texture = _model.Image;
            _component.author.text = _model.Author;
            _component.album.text = _model.Album;
            _component.link.text = _model.Link;
            _component.title.text = _model.Title;
            _component.Label.text = _model.Label;
            if (!string.IsNullOrEmpty(_model.Label))
            {
                _component.DMCa.text = "DMCA";
            }
            else
            {
                _component.DMCa.text = "FREE";
            }

            _component.Root.SetActive(true);
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
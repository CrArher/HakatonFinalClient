using DefaultNamespace;
using UnityEngine;

namespace ScreenManager.ScreenChanger
{
    public class ScreenChangerUnitController : IController
    {
        private readonly GlobalContext _context;
        private readonly ScreenChangerUnitModel _model;
        private readonly GameObject _screenRoot;

        public ScreenChangerUnitController(GlobalContext context,ScreenChangerUnitModel model , GameObject screenRoot)
        {
            _context = context;
            _model = model;
            _screenRoot = screenRoot;
        }
        public void Deactivate()
        {
            _model.Hided -= OnHide;
            _model.Showed -= OnShow;

        }

        public void Activate()
        {
            _model.Hided += OnHide;
            _model.Showed += OnShow;

        }

        private void OnHide()
        {
            _screenRoot.SetActive(false);
        }

        private void OnShow()
        {
            _screenRoot.SetActive(true);
        }
    }
}
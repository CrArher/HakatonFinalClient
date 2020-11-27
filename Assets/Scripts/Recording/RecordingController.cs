using UnityEngine;

namespace DefaultNamespace.Recording
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
            _component.Record.onClick.RemoveListener(OnRecord);
        }

        public void Activate()
        {
            _component.Record.onClick.AddListener(OnRecord);
        }

        private void OnRecord()
        {
            _model.IsRecording = !_model.IsRecording;
            if (_model.IsRecording)
            {
                _component.Record.image.color = Color.red;
            }
            else
            {
                _component.Record.image.color = Color.white;
            }
            _model.Record();
        }
    }
}
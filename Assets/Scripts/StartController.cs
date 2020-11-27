using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Recording;
using UnityEngine;

public class StartController : MonoBehaviour
{
    private ControllerCollection _controllerCollection = new ControllerCollection();
    private GlobalContext _context = new GlobalContext();
    public RecordingComponent RecordingComponent;
    private void Awake()
    {
        RecordingModel model = new RecordingModel();
        RecordingController controller = new RecordingController(_context,model,RecordingComponent);
        controller.Activate();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

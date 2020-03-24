using UnityEngine;
using System.Collections;

public class SnapPanelController : PanelController
{
    public GameObject SnapJumper;
    public override void Start()
    {
        stateCount = 4;
        Name = "Snap";
        base.Start();
    }
    
    public void ResetPreviousState()
    {
        previousState = -1;
    }
}

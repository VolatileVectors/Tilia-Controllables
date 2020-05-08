using UnityEngine;
using UnityEngine.Serialization;

public class SnapPanelController : PanelController
{
    [FormerlySerializedAs("SnapJumper")] public GameObject snapJumper;

    public override void Start()
    {
        StateCount = 4;
        panelName = "Snap";
        base.Start();
    }

    public void ResetPreviousState()
    {
        PreviousState = -1;
    }
}
using UnityEngine;
using System.Collections;

public class LeverPanelController : PanelController
{
    // Start is called before the first frame update
    public override void Start()
    {
        stateCount = 2;
        Name = "Lever";
        base.Start();
    }
}

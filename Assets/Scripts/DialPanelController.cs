using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPanelController : PanelController
{
    // Start is called before the first frame update
    public override void Start()
    {
        stateCount = 5;
        Name = "Dial";
        currentState = 2;
        previousState = 2;
        base.Start();
    }
}
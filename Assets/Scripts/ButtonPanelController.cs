using System.Collections.Generic;
using Tilia.Interactions.Controllables.LinearDriver;

public class ButtonPanelController : PanelController
{
    public override void Start()
    {
        stateCount = 3;
        Name = "Button";
        base.Start();
        ResetPreviousState();
    }

    public void ResetPreviousState()
    {
        previousState = -1;
    }
}

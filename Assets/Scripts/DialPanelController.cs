public class DialPanelController : PanelController
{
    public override void Start()
    {
        StateCount = 5;
        panelName = "Dial";
        CurrentState = 2;
        PreviousState = 2;
        base.Start();
    }
}
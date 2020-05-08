public class ButtonPanelController : PanelController
{
    public override void Start()
    {
        StateCount = 3;
        panelName = "Button";
        base.Start();
        ResetPreviousState();
    }

    public void ResetPreviousState()
    {
        PreviousState = -1;
    }
}
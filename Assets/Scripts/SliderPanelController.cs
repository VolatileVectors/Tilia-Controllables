public class SliderPanelController : PanelController
{
    public override void Start()
    {
        StateCount = 4;
        panelName = "Slider";
        base.Start();
    }

    public override void SetLights()
    {
        for (int i = 0; i < StateCount; ++i)
        {
            if (i <= CurrentState)
            {
                lights[i].TurnOn();
            }
            else
            {
                lights[i].TurnOff();
            }
        }
    }
}
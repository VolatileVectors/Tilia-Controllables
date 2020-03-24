using UnityEngine;
using System.Collections;

public class SliderPanelController : PanelController
{
    // Start is called before the first frame update
    public override void Start()
    {
        stateCount = 4;
        Name = "Slider";
        base.Start();
    }

    public override void SetLights()
    {
        for (int i = 0; i < stateCount; ++i)
        {
            if (i <= currentState)
            {
                Lights[i].TurnOn();
            }
            else
            {
                Lights[i].TurnOff();
            }
        }
    }
}

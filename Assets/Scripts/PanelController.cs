using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PanelController : MonoBehaviour
{
    [Serializable]
    public class PanelEvent : UnityEvent<string, int>
    {
    }

    public string Name = "Panel";

    public List<BulbController> Lights = new List<BulbController>();
    public AudioCue StateChangeCue;

    protected List<AudioSource> audioSourcePool = new List<AudioSource>();
    protected int currentSource = 0;

    protected int previousState = 0;
    protected int currentState = 0;
    protected int stateCount = 0;

    public PanelEvent StateChangedEvent = new PanelEvent();

    public virtual void Start()
    {
        audioSourcePool.AddRange(GetComponents<AudioSource>());

        if (Lights.Count > currentState)
        {
            Lights[currentState].TurnOn();
        }
    }

    public virtual void SwitchState(float step)
    {
        currentState = (int) step;
        if (previousState != currentState)
        {
            SetLights();

            if (StateChangeCue)
            {
                StateChangeCue.Play(audioSourcePool[currentSource++]);
                currentSource %= audioSourcePool.Count;
            }

            if (StateChangedEvent != null)
            {
                StateChangedEvent.Invoke(Name, currentState + 1);
            }
        }

        previousState = currentState;
    }

    public virtual void SetLights()
    {
        if (Lights.Count > previousState && previousState >= 0)
        {
            Lights[previousState].TurnOff();
        }

        if (Lights.Count > currentState)
        {
            Lights[currentState].TurnOn();
        }
    }
}
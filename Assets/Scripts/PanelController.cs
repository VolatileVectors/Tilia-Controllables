using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class PanelController : MonoBehaviour
{
    [Serializable]
    public class PanelEvent : UnityEvent<string, int>
    {
    }

    [FormerlySerializedAs("Name")] public string panelName = "Panel";

    [FormerlySerializedAs("Lights")] public List<BulbController> lights = new List<BulbController>();

    [FormerlySerializedAs("StateChangeCue")]
    public AudioCue stateChangeCue;

    private readonly List<AudioSource> _audioSourcePool = new List<AudioSource>();
    private int _currentSource;

    protected int PreviousState;
    protected int CurrentState;
    protected int StateCount = 0;

    [FormerlySerializedAs("StateChangedEvent")]
    public PanelEvent stateChangedEvent = new PanelEvent();

    public virtual void Start()
    {
        _audioSourcePool.AddRange(GetComponents<AudioSource>());

        if (lights.Count > CurrentState)
        {
            lights[CurrentState].TurnOn();
        }
    }

    public virtual void SwitchState(float step)
    {
        CurrentState = (int) step;
        if (PreviousState != CurrentState)
        {
            SetLights();

            if (stateChangeCue)
            {
                stateChangeCue.Play(_audioSourcePool[_currentSource++]);
                _currentSource %= _audioSourcePool.Count;
            }

            if (stateChangedEvent != null)
            {
                stateChangedEvent.Invoke(panelName, CurrentState + 1);
            }
        }

        PreviousState = CurrentState;
    }

    public virtual void SetLights()
    {
        if (lights.Count > PreviousState && PreviousState >= 0)
        {
            lights[PreviousState].TurnOff();
        }

        if (lights.Count > CurrentState)
        {
            lights[CurrentState].TurnOn();
        }
    }
}
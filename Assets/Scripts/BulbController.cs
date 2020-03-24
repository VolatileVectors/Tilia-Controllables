using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbController : MonoBehaviour
{
    public Color LightOff = Color.black;
    public Color LightOn = new Color(1f, 0.3f, 0f);
    public float TransitionTime = 0.5f;

    private Material lightMat;
    private Color currentColor;
    private float transition = 0f;
    private int transitionDirection = -1;

    void Start()
    {
        lightMat = GetComponentInChildren<Renderer>().material;
        lightMat.SetColor("_EmissionColor", LightOff);
    }

    public void TurnOn()
    {
        if (transitionDirection == -1)
        {
            transitionDirection = 1;
        }
    }

    public void TurnOff()
    {
        if (transitionDirection == 1)
        {
            transitionDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((transitionDirection == -1 && transition > 0f) || (transitionDirection == 1 && transition < 1f))
        {
            transition += Time.deltaTime / TransitionTime * transitionDirection;
            lightMat.SetColor("_EmissionColor", Color.Lerp(LightOff, LightOn, transition));
        }
    }
}

using UnityEngine;

public class BulbController : MonoBehaviour
{
    public Color lightOff = Color.black;
    public Color lightOn = new Color(1f, 0.3f, 0f);
    public float transitionTime = 0.5f;

    private Material _lightMat;
    private Color _currentColor;
    private float _transition;
    private int _transitionDirection = -1;

    private void Start()
    {
        _lightMat = GetComponentInChildren<Renderer>().material;
        _lightMat.SetColor("_EmissionColor", lightOff);
    }

    public void TurnOn()
    {
        if (_transitionDirection == -1)
        {
            _transitionDirection = 1;
        }
    }

    public void TurnOff()
    {
        if (_transitionDirection == 1)
        {
            _transitionDirection = -1;
        }
    }

    private void Update()
    {
        if ((_transitionDirection == -1 && _transition > 0f) || (_transitionDirection == 1 && _transition < 1f))
        {
            _transition += Time.deltaTime / transitionTime * _transitionDirection;
            _lightMat.SetColor("_EmissionColor", Color.Lerp(lightOff, lightOn, _transition));
        }
    }
}
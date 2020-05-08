using TMPro;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ScreenController : MonoBehaviour
{
    [FormerlySerializedAs("TextMesh")] public TextMeshPro textMesh;
    private string[] _lines;

    private void Start()
    {
        _lines = new string[8];
        ClearMessages();
    }

    public void ClearMessages()
    {
        for (int i = 0; i < 8; ++i)
        {
            _lines[i] = " ";
        }

        textMesh.text = string.Join(Environment.NewLine, _lines);
    }

    public void PrintMessage(string msg, int state)
    {
        for (int i = 7; i > 0; --i)
        {
            _lines[i] = _lines[i - 1];
        }

        _lines[0] = msg + " set to " + state;
        textMesh.text = string.Join(Environment.NewLine, _lines);
    }
}
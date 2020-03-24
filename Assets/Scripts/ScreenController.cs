using TMPro;
using System;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public TextMeshPro TextMesh;
    protected string[] lines;
    void Start()
    {
        lines = new string[8];
        ClearMessages();
    }

    public void ClearMessages()
    {
        for (int i = 0; i < 8; ++i)
        {
            lines[i] = " ";
        }
        TextMesh.text = string.Join(Environment.NewLine, lines);
    }

    public void PrintMessage(string name, int state)
    {
        for (int i = 7; i > 0; --i)
        {
            lines[i] = lines[i - 1];
        }
        lines[0] = name + " set to " + state;
        TextMesh.text = string.Join(Environment.NewLine, lines);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.SnapZone;

public class SnapJumperController : MonoBehaviour
{
    public SnapZoneFacade dropZone = null;

    void Start()
    {
        dropZone.Snap(gameObject);
    }

    public void SetLastDropZone(GameObject lastDropZone)
    {
        Debug.Log("Snapped jumper to: " + lastDropZone.name);
        dropZone = lastDropZone.GetComponent<SnapZoneFacade>();
    }

    public void ReSnap()
    {
        if (dropZone != null)
        {
            dropZone.Snap(gameObject);
        }
    }
}
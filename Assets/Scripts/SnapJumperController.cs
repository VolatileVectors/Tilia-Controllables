using UnityEngine;
using Tilia.Interactions.SnapZone;

public class SnapJumperController : MonoBehaviour
{
    public SnapZoneFacade dropZone;

    private void Start()
    {
        ReSnap();
    }

    public void SetLastDropZone(GameObject lastDropZone)
    {
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
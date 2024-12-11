using UnityEngine;

public class NailView : MonoBehaviour
{
    public delegate void NailClickedHandler(NailView nailView);
    public event NailClickedHandler OnNailClicked;

    private void OnMouseDown()
    {
        OnNailClicked?.Invoke(this);
    }

    public void RemoveVisual()
    {
        Destroy(gameObject);
    }
}

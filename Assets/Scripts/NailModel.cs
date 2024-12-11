using UnityEngine;

public class NailModel
{
    public bool IsRemoved { get; private set; }

    public void RemoveNail()
    {
        IsRemoved = true;
    }
}

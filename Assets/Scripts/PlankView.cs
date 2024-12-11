using UnityEngine;

public class PlankView : MonoBehaviour
{
    public void Fall()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}

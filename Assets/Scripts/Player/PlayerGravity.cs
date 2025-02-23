using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddGravity(float value)
    {
        if (rb.gravityScale.Equals(1)) rb.linearVelocityY = value;
    }

    public void SwitchGravity()
    {
        rb.linearVelocityY = 0f;
        rb.gravityScale = rb.gravityScale.Equals(1) ? 0 : 1;
    }
}

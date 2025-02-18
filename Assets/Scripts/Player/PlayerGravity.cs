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
        rb.linearVelocityY = value;
    }

    public void SwitchGravity()
    {
        rb.gravityScale = rb.gravityScale.Equals(1) ? 0 : 1;
    }
}

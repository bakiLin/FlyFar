using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float minForce, midForce, maxForce;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(float powerBarValue)
    {
        float jumpForce;

        if (powerBarValue <= 0.5f) jumpForce = minForce;
        else if (powerBarValue <= 0.8f) jumpForce = midForce;
        else jumpForce = maxForce;

        rb.linearVelocityY = jumpForce;
    }
}

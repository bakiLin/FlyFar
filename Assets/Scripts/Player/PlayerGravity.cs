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
        if (powerBarValue <= 0.5f) rb.linearVelocityY = minForce;
        else if (powerBarValue <= 0.8f) rb.linearVelocityY = midForce;
        else rb.linearVelocityY = maxForce;
    }
}

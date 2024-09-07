using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float gravity;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool grounded;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if (!grounded && moveDirection.y > gravity )
            moveDirection.y += gravity * Time.deltaTime;
        else if (grounded && moveDirection.y < 0f)
            moveDirection.y = 0f;
    }

    private void FixedUpdate() => rb.velocity = moveDirection;

    public void Jump(float power) => moveDirection.y = power;

    public void IsGrounded(bool state) => grounded = state;
}

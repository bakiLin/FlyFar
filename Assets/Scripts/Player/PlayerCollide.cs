using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private PlayerGravity playerGravity;

    private void Awake() => playerGravity = GetComponent<PlayerGravity>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
            playerGravity.IsGrounded(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            playerGravity.IsGrounded(false);
    }
}

using UnityEngine;
using Zenject;

public class PlayerCollide : MonoBehaviour
{
    [Inject]
    private PlayerGravity playerGravity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) playerGravity.SetColls(1);

        if (collision.collider.CompareTag("Ball"))
        {
            collision.gameObject.SetActive(false);
            playerGravity.SetUpForce(10f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            playerGravity.SetColls(-1);
    }
}

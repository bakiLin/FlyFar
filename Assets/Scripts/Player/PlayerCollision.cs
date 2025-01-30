using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (playerSpeed.GetSpeed() > 3f)
                playerSpeed.SetSpeed(playerSpeed.GetSpeed() - 3f);
        }
    }
}

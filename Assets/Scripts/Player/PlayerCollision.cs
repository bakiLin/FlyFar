using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private float speedLoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (playerSpeed.GetSpeed() > speedLoss)
            {
                playerSpeed.SetSpeed(playerSpeed.GetSpeed() - speedLoss);
            }

            var collisionBehavior = collision.GetComponent<IEnemyCollisionBehavior>();

            playerGravity.AddGravity(collisionBehavior.CollisionBehavior());
        }
    }
}

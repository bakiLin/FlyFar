using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private GameManage gameManage;

    [SerializeField]
    private float speedLoss, groundForce;

    [HideInInspector]
    public bool isStarted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var collisionBehavior = collision.GetComponent<IEnemyCollisionBehavior>();

            playerGravity.AddGravity(collisionBehavior.CollisionBehavior());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && isStarted)
        {
            if (playerSpeed.GetSpeed() > speedLoss)
            {
                float speed = playerSpeed.GetSpeed() - speedLoss;

                playerSpeed.SetSpeed(speed);
            }
            else
            {
                playerSpeed.SetSpeed(0f);
                gameManage.StopGame();
            }

            if (isStarted) playerGravity.AddGravity(groundForce);
        }
    }
}

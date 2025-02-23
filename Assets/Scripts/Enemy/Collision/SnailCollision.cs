using UnityEngine;
using Zenject;

public class SlimeCollision : EnemyCollision
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float speedLoss;

    public override float Collide()
    {
        playerSpeed.AddSpeed(-speedLoss);

        return base.Collide();
    }
}

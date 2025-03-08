using DG.Tweening;
using UnityEngine;
using Zenject;

public class GhostCollision : EnemyCollision
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerParticleManager playerParticleManager;

    [SerializeField]
    private float speedLoss;

    public override float Collide()
    {
        if (!playerParticleManager.isFalling) playerSpeed.AddSpeed(-playerSpeed.speed.Value * speedLoss);

        transform.DOMoveY(-3f, 5f)
            .SetSpeedBased()
            .SetEase(Ease.Linear);

        return base.Collide();
    }
}

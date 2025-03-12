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

    private ShipMovement shipMovement;

    protected override void Awake()
    {
        base.Awake();
        shipMovement = GetComponent<ShipMovement>();
    }

    public override float Collide()
    {
        if (!playerParticleManager.isFalling) playerSpeed.AddSpeed(-playerSpeed.speed.Value * speedLoss);

        shipMovement.enabled = false;

        transform.DOMoveY(-2f, 2f)
            .SetSpeedBased()
            .SetEase(Ease.Linear);

        return base.Collide();
    }
}

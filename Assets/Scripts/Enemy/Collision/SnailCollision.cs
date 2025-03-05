using DG.Tweening;
using UnityEngine;
using Zenject;

public class SlimeCollision : EnemyCollision
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerParticleManager playerParticleManager;

    [SerializeField]
    private float speedLoss;

    private EnemyMovement enemyMovement;

    protected override void Awake()
    {
        base.Awake();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public override float Collide()
    {
        if (!playerParticleManager.isFalling) playerSpeed.AddSpeed(-playerSpeed.speed.Value * speedLoss);
        enemyMovement.Stop();

        Sequence sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + 1f, 0.25f).SetEase(Ease.OutCubic))
            .Append(transform.DOMoveY(transform.position.y, 0.25f).SetEase(Ease.InQuad));

        return base.Collide();
    }
}

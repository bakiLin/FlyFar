using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class GhostCollision : EnemyCollision
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerParticleManager playerParticleManager;

    [SerializeField]
    private float[] speedLoss;

    private float loss;

    protected override void Awake()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        loss = speedLoss[YandexGame.savesData.GetPlayerLevel(index)[1]];
        base.Awake();
    }

    public override (float, int) Collide()
    {
        if (!playerParticleManager.isFalling) playerSpeed.AddSpeed(-playerSpeed.speed.Value * loss);
        GetComponent<EnemyMovement>().tween.Kill();
        transform.DOMoveY(-2f, 3f)
            .SetSpeedBased()
            .SetEase(Ease.Linear);

        return base.Collide();
    }
}

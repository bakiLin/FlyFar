using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private TextManager textManager;

    [Inject]
    private PlayerParticleManager playerParticleManager;

    public CompositeDisposable disposable = new CompositeDisposable();

    private void Awake()
    {
        inputScript.onStart += () => {
            GroundCollision();
            EnemyTrigger();
        };

        playerSpeed.onStop += disposable.Clear;
    }

    private void GroundCollision()
    {
        GetComponent<Collider2D>().OnCollisionEnter2DAsObservable().Where(_ => _.transform.CompareTag("Ground"))
            .Subscribe(_ => {
                GroundCollision groundCollision = _.transform.GetComponent<GroundCollision>();
                if (!playerParticleManager.isFalling) playerSpeed.AddSpeed(-playerSpeed.speed.Value * groundCollision.loss);
                if (playerSpeed.speed.Value > playerSpeed.stopSpeed) playerGravity.Bounce(groundCollision.force);
            }).AddTo(disposable);
    }

    private void EnemyTrigger()
    {
        GetComponent<Collider2D>().OnTriggerEnter2DAsObservable().Where(_ => _.gameObject.CompareTag("Enemy"))
            .Subscribe(_ => {
                AudioManager.Instance.Play("hit", true);
                (float force, int coin) = _.transform.GetComponent<EnemyCollision>().Collide();
                playerGravity.Bounce(force);
                textManager.SetCoin(coin);
            }).AddTo(disposable);
    }
}

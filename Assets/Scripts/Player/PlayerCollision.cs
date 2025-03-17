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

    [Inject]
    private GameOver gameOver;

    private CompositeDisposable disposable = new CompositeDisposable();

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void GroundCollision()
    {
        GetComponent<Collider2D>()
            .OnCollisionEnter2DAsObservable()
            .Where(obj => obj.transform.CompareTag("Ground"))
            .Subscribe(obj => {
                GroundCollision groundCollision = obj.transform.GetComponent<GroundCollision>();
                if (!playerParticleManager.isFalling) playerSpeed.AddSpeed(-playerSpeed.speed.Value * groundCollision.multiply);
                if (playerSpeed.speed.Value > 5f) playerGravity.Bounce(groundCollision.force);
                else disposable.Clear();
            }).AddTo(disposable);
    }

    private void EnemyTrigger()
    {
        GetComponent<Collider2D>()
            .OnTriggerEnter2DAsObservable()
            .Where(obj => obj.gameObject.CompareTag("Enemy"))
            .Subscribe(obj => {
                audioManager.Play("hit", true);
                gameOver.delay = true;
                EnemyCollision enemyCollision = obj.GetComponent<EnemyCollision>();
                playerGravity.Bounce(enemyCollision.Collide());
                textManager.SetCoin(enemyCollision.Score());
                if (playerSpeed.speed.Value < 5f) disposable.Clear();
                gameOver.delay = false;
            }).AddTo(disposable);
    }

    private void OnEnable()
    {
        inputScript.onStart += GroundCollision;
        inputScript.onStart += EnemyTrigger;
    }

    private void OnDisable()
    {
        inputScript.onStart -= GroundCollision;
        inputScript.onStart -= EnemyTrigger;
    }
}

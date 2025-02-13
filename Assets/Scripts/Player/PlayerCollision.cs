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
    private UITextManager textManager;

    [SerializeField]
    private float speedLoss, groundForce;
    
    private CompositeDisposable disposable = new CompositeDisposable();

    private Collider2D playerCollider;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    private void GroundCollision()
    {
        playerCollider.OnCollisionEnter2DAsObservable()
            .Where(_ => _.gameObject.CompareTag("Ground"))
            .Subscribe(_ => {
                playerSpeed.AddSpeed(-speedLoss);
                if (playerSpeed.GetSpeed() > 0f) playerGravity.AddGravity(groundForce);
                else disposable.Clear();
            }).AddTo(disposable);
    }

    private void EnemyTrigger()
    {
        playerCollider.OnTriggerEnter2DAsObservable()
            .Where(_ => _.gameObject.CompareTag("Enemy"))
            .Subscribe(enemy => {
                EnemyCollision enemyCollision = enemy.GetComponent<EnemyCollision>();
                playerGravity.AddGravity(enemyCollision.Collide());
                textManager.SetCoin(enemyCollision.Score());
            }).AddTo(disposable);
    }

    private void Collide()
    {
        GroundCollision();
        EnemyTrigger();
    }

    private void OnEnable()
    {
        inputScript.onStart += Collide;
    }

    private void OnDisable()
    {
        inputScript.onStart -= Collide;
    }
}

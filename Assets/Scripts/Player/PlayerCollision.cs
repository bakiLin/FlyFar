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
    private int speedLoss, groundForce;
    
    private CompositeDisposable disposable = new CompositeDisposable();

    private Collider2D playerCollider;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    private void Collide()
    {
        playerCollider.OnCollisionEnter2DAsObservable()
            .Where(x => x.gameObject.CompareTag("Ground"))
            .Subscribe(_ => 
            {
                if (playerSpeed.GetSpeed() > speedLoss)
                {
                    playerSpeed.SetSpeed(playerSpeed.GetSpeed() - speedLoss);
                    playerGravity.AddGravity(groundForce);
                }
                else
                {
                    playerSpeed.SetSpeed(0);
                    disposable.Clear();
                }

                textManager.SetSpeed(playerSpeed.GetSpeed());
            }).AddTo(disposable);

        playerCollider.OnTriggerEnter2DAsObservable()
            .Where(x => x.gameObject.CompareTag("Enemy"))
            .Subscribe(_ =>
            {
                var collisionBehavior = _.GetComponent<IEnemyCollision>();
                playerGravity.AddGravity(collisionBehavior.CollisionBehavior());

                var enemyScore = _.GetComponent<EnemyScore>();
                textManager.SetCoin(enemyScore.GetScore());

            }).AddTo(disposable);
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

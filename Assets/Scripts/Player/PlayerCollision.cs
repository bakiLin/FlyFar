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

    [SerializeField]
    private float speedLoss, groundForce;
    
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
                    playerSpeed.SetSpeed(0f);
                    disposable.Clear();
                }
            }).AddTo(disposable);

        playerCollider.OnTriggerEnter2DAsObservable()
            .Where(x => x.gameObject.CompareTag("Enemy"))
            .Subscribe(_ =>
            {
                var collisionBehavior = _.GetComponent<IEnemyCollisionBehavior>();
                playerGravity.AddGravity(collisionBehavior.CollisionBehavior());
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

using UnityEngine;
using UniRx;
using Zenject;
using Cysharp.Threading.Tasks;

public class PlayerParticleManager : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private FlyBar flyBar;

    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private float speedBarier;

    private ParticleSystem particle;

    private Rigidbody2D rb;

    private CompositeDisposable disposable = new CompositeDisposable();

    public bool isFalling { get; private set; }

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        rb = transform.parent.GetComponent<Rigidbody2D>();

        Observable.EveryUpdate()
            .Where(_ => rb.linearVelocityY < speedBarier && !isFalling)
            .Subscribe(_ => {
                audioManager.Play("Fall");
                isFalling = true;
                particle.Play();
                Accelerate().Forget();
            }).AddTo(disposable);

        Observable.EveryUpdate()
            .Where(_ => rb.linearVelocityY > 0f && isFalling)
            .Subscribe(_ => StopFalling())
            .AddTo(disposable);
    }

    public void StopFalling()
    {
        audioManager.Stop("Fall");
        isFalling = false;
        particle.Stop();
        particle.Clear();
        flyBar.StopFill();
    }

    private async UniTaskVoid Accelerate()
    {
        flyBar.Fill().Forget();

        while (isFalling)
        {
            playerSpeed.AddSpeed(1f);
            await UniTask.Delay(500, cancellationToken: destroyCancellationToken);
        }
    }

    private void OnEnable()
    {
        playerSpeed.onStop += () => { 
            particle.Stop();
            disposable.Clear(); 
        };
    }

    private void OnDestroy()
    {
        disposable.Clear();
    }
}

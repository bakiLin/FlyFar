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

    [SerializeField]
    private float speedBarier;

    public bool isFalling { get; private set; }

    private ParticleSystem particle;

    private Rigidbody2D rb;

    private CompositeDisposable disposable = new CompositeDisposable();

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        particle = GetComponent<ParticleSystem>();
        rb = transform.parent.GetComponent<Rigidbody2D>();

        Observable.EveryUpdate()
            .Where(_ => rb.linearVelocityY < speedBarier && !isFalling)
            .Subscribe(_ => {
                audioManager.Play("fall", true);
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
        audioManager.Play("fall", false);
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

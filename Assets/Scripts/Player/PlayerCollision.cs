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

    private CompositeDisposable disposable = new CompositeDisposable();

    private void GroundCollision()
    {
        GetComponent<Collider2D>()
            .OnCollisionEnter2DAsObservable()
            .Where(obj => obj.transform.CompareTag("Ground"))
            .Subscribe(obj => {
                GroundCollision groundCollision = obj.transform.GetComponent<GroundCollision>();
                playerSpeed.AddSpeed(-groundCollision.SpeedLoss());
                if (playerSpeed.speed > 5f) playerGravity.AddGravity(groundCollision.Force());
                else disposable.Clear();
            }).AddTo(disposable);
    }

    private void EnemyTrigger()
    {
        GetComponent<Collider2D>()
            .OnTriggerEnter2DAsObservable()
            .Where(obj => obj.gameObject.CompareTag("Enemy"))
            .Subscribe(obj => { 
                EnemyCollision enemyCollision = obj.GetComponent<EnemyCollision>();
                playerGravity.AddGravity(enemyCollision.Collide());
                textManager.SetCoin(enemyCollision.Score());
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

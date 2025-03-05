using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = System.Random;
using UniRx;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    private Tween tween;

    private Random random = new Random();

    public CompositeDisposable disposable = new CompositeDisposable();

    private void Move(float direction, float speed)
    {
        double multiply = random.NextDouble() * 0.6 + 0.5;

        tween.Kill();
        tween = transform.DOMoveX(direction, speed * (float) multiply)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => { gameObject.SetActive(false); });
    }

    private void OnEnable()
    {
        if (playerSpeed.speed.Value > 0f) Move(-20f, Mathf.Clamp(playerSpeed.speed.Value, 5f, 25f));
        else Move(20f, 7f);

        playerSpeed.speed.Subscribe(speed => { 
            if (speed > 5f) Move(-20f, Mathf.Clamp(speed, 5f, 25f));
            else Move(20f, 7f);
        }).AddTo(disposable);
    }

    private void OnDisable() => disposable.Clear();

    public void Stop()
    {
        disposable.Clear();
        Move(-20f, playerSpeed.speed.Value);
    }
}

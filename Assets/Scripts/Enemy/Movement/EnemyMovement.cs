using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    private Tween tween;

    private Random random = new Random();

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
        if (playerSpeed.speed > 0f) Move(-20f, playerSpeed.speed);
        else Move(20f, 7f);

        playerSpeed.onChange += () => { Move(-20f, playerSpeed.speed); };
        playerSpeed.onStop += () => { Move(20f, 7f); };
    }
}

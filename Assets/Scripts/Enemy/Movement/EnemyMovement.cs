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

    private float direction, speed;

    private void Move()
    {
        double range = 1.1 - 0.5;
        double multiply = (random.NextDouble() * range) + 0.5;

        if (playerSpeed.GetSpeed() > 0f)
        {
            direction = -20f;
            speed = playerSpeed.GetSpeed() * (float) multiply;
        }
        else
        {
            direction = 20f;
            speed = 5f;
        }

        tween.Kill();
        tween = transform.DOMoveX(direction, speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => { gameObject.SetActive(false); });
    }

    private void OnEnable()
    {
        Move();

        playerSpeed.onChange += Move;
    }

    private void OnDisable()
    {
        playerSpeed.onChange -= Move;
    }
}

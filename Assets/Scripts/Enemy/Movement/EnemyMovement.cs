using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    public Tween tween;

    private Random random = new Random();

    private void Awake()
    {
        playerSpeed.onChange += Move;
        playerSpeed.onStop += Move;
    }

    private void OnEnable()
    {
        Move();
    }

    public void Move()
    {
        tween.Kill();

        if (playerSpeed.speed.Value > playerSpeed.stopSpeed)
        {
            float randomValue = (float) random.NextDouble() * 0.6f + 0.5f;
            tween = transform.DOMoveX(-25f, playerSpeed.speed.Value * randomValue)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => { gameObject.SetActive(false); });
        }
        else
        {
            tween = transform.DOMoveX(25f, 7f)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => { gameObject.SetActive(false); });
        }
    }
}

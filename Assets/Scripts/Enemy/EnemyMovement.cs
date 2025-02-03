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

    private void Move()
    {
        Vector3 position = new Vector3(-15f, transform.position.y);

        float multiply = ((float)random.Next(4, 12)) / 10;

        tween.Kill();
        tween = transform.DOMove(position, playerSpeed.GetSpeed() * multiply)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }

    private void ChangeSpeed()
    {
        tween.Kill();

        Move();
    }

    private void OnEnable()
    {
        Move();

        playerSpeed.onChanged += ChangeSpeed;
    }

    private void OnDisable()
    {
        playerSpeed.onChanged -= ChangeSpeed;
    }
}

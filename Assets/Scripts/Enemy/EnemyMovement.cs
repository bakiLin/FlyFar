using DG.Tweening;
using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    private Tween tween;

    private void Move()
    {
        Vector3 position = new Vector3(-15f, transform.position.y);

        tween.Kill();
        tween = transform.DOMove(position, playerSpeed.GetSpeed())
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

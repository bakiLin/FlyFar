using DG.Tweening;
using UnityEngine;
using Zenject;

public class BackgroundMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float multiply, movePosition;

    private Tween tween;

    private void Move()
    {
        tween.Kill();

        tween = transform.DOMoveX(movePosition, playerSpeed.GetSpeed() * multiply)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                transform.position = new Vector3(0f, transform.position.y);
                Move();
            });
    }

    private void OnEnable()
    {
        playerSpeed.onChange += Move;
    }

    private void OnDisable()
    {
        playerSpeed.onChange -= Move;
    }
}

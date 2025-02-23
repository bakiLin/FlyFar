using DG.Tweening;
using UnityEngine;
using Zenject;

public class ShipMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float speed;

    private Sequence sequence;

    private Tween tween;

    private void OnEnable()
    {
        if (playerSpeed.speed > 0f) Move(-20f);
        else Move(20f);

        VerticalMove();
    }

    private void Move(float direction)
    {
        tween.Kill();
        tween = transform.DOMoveX(direction, speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => { gameObject.SetActive(false); });
    }

    private void VerticalMove()
    {
        sequence.Kill();
        sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + 1f, 1f).SetEase(Ease.OutQuad))
            .Append(transform.DOMoveY(transform.position.y, 1f).SetEase(Ease.OutQuad))
            .SetLoops(-1);
    }

    public void Stop()
    {
        tween.Kill();
        sequence.Kill();
    }
}

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
        if (playerSpeed.speed.Value > 0f) Move(-25f);
        else Move(25f);

        playerSpeed.onStop += MoveForward;
    }

    private void OnDisable()
    {
        tween.Kill();
        sequence.Kill();

        playerSpeed.onStop -= MoveForward;
    }

    private void MoveForward() => Move(25f);

    private void Move(float direction)
    {
        sequence.Kill();
        sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + 1f, 1f).SetEase(Ease.OutQuad))
            .Append(transform.DOMoveY(transform.position.y, 1f).SetEase(Ease.OutQuad))
            .SetLoops(-1);

        tween.Kill();
        tween = transform.DOMoveX(direction, speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => { gameObject.SetActive(false); });
    }

    public void Stop()
    {
        tween.Kill();
        sequence.Kill();
    }
}

using DG.Tweening;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public Sequence sequence;

    private void OnEnable() => Move();

    private void OnDisable() => sequence.Kill();

    private void Move()
    {
        sequence.Kill();
        sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + 2f, 1f).SetEase(Ease.OutQuad))
            .Append(transform.DOMoveY(transform.position.y, 1f).SetEase(Ease.OutQuad))
            .SetLoops(-1);
    }
}

using DG.Tweening;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Sequence sequence;

    private void OnEnable()
    {
        sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + 1f, 1f).SetEase(Ease.Linear))
            .Append(transform.DOMoveY(transform.position.y, 1f).SetEase(Ease.Linear))
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        sequence.Kill();
    }
}

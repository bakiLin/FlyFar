using DG.Tweening;
using UnityEngine;

public class WindowAnimation : MonoBehaviour
{
    [SerializeField]
    private RectTransform window;

    [SerializeField]
    private float positionY;

    private Tween tween;

    private bool movingDown;

    public void MoveDown()
    {
        if (!movingDown)
        {
            tween.Kill();
            tween = window.DOAnchorPosY(positionY, 0.7f);
        }

        movingDown = true;
    }

    public void MoveUp()
    {
        if (movingDown)
        {
            tween.Kill();
            tween = window.DOAnchorPosY(300f, 0.7f);
        }

        movingDown = false;
    }
}

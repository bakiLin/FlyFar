using DG.Tweening;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform settings;

    [SerializeField]
    private float movePoint;

    private bool settingsOn;

    private Tween tween;

    public void SwitchSettings()
    {
        if (!settingsOn)
        {
            tween.Kill();
            tween = settings.DOAnchorPosY(movePoint, 0.7f);
        }
        else
        {
            tween.Kill();
            tween = settings.DOAnchorPosY(300f, 0.7f);
        }

        settingsOn = !settingsOn;
    }

    public void MoveUp()
    {
        tween.Kill();
        tween = settings.DOAnchorPosY(300f, 0.7f);

        settingsOn = false;
    }
}

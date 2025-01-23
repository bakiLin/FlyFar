using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PowerBarArrow : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject powerBar;

    private Sequence sequence;

    private void Awake()
    {
        sequence = DOTween.Sequence()
            .Append(slider.DOValue(1f, 1f).SetEase(Ease.InCubic))
            .Append(slider.DOValue(0f, 1f).SetEase(Ease.OutCubic))
            .SetLoops(-1);
    }

    public float StopArrow()
    {
        sequence.Kill();
        powerBar.SetActive(false);

        return slider.value;
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class PowerBarArrow : MonoBehaviour
{
    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private InputScript inputScript;

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

    public void StopArrow()
    {
        sequence.Kill();
        powerBar.SetActive(false);

        playerGravity.Jump(slider.value);
        playerSpeed.Jump(slider.value);
    }

    private void OnEnable()
    {
        inputScript.onStart += StopArrow;
    }

    private void OnDisable()
    {
        inputScript.onStart -= StopArrow;
    }
}

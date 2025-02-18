using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class PowerBar : MonoBehaviour
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
    private float multiply;

    private Sequence sequence;

    private void Awake()
    {
        sequence = DOTween.Sequence()
            .Append(slider.DOValue(1f, 1f).SetEase(Ease.InCubic))
            .Append(slider.DOValue(0f, 1f).SetEase(Ease.OutCubic))
            .SetLoops(-1);
    }

    private void Stop()
    {
        sequence.Kill();

        slider.transform.parent.gameObject.SetActive(false);

        float value = Mathf.Clamp(slider.value * multiply, 10f, 1000f);
        playerGravity.AddGravity(Mathf.RoundToInt(value));
        playerSpeed.AddSpeed(Mathf.RoundToInt(value));
    }

    private void OnEnable()
    {
        inputScript.onStart += Stop;
    }

    private void OnDisable()
    {
        inputScript.onStart -= Stop;
    }
}

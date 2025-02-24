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
    private float multiply;

    [SerializeField]
    private Image fill;

    private Sequence sequence;

    private void Awake()
    {
        sequence = DOTween.Sequence()
            .Append(fill.DOFillAmount(1f, 1f).SetEase(Ease.InCubic))
            .Append(fill.DOFillAmount(0f, 1f).SetEase(Ease.OutCubic))
            .SetLoops(-1);
    }

    private void Stop()
    {
        sequence.Kill();

        float value = Mathf.Clamp(fill.fillAmount * multiply, 10f, 1000f);
        playerGravity.AddGravity(Mathf.RoundToInt(value));
        playerSpeed.AddSpeed(Mathf.RoundToInt(value));

        fill.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable() => inputScript.onStart += Stop;

    private void OnDisable() => inputScript.onStart -= Stop;
}

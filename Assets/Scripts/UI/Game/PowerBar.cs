using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using YG;
using Cysharp.Threading.Tasks;

public class PowerBar : MonoBehaviour
{
    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private InputScript inputScript;

    [SerializeField]
    private float[] levelMultiply;

    [SerializeField]
    private Image fill;

    private Sequence sequence;

    private float multiply;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        int level = YandexGame.savesData.playerLevel[4];
        multiply = levelMultiply[level];

        sequence = DOTween.Sequence()
            .Append(fill.DOFillAmount(1f, 1f).SetEase(Ease.InCubic))
            .Append(fill.DOFillAmount(0f, 1f).SetEase(Ease.OutCubic))
            .SetLoops(-1);
    }

    private void Stop()
    {
        sequence.Kill();

        float value = Mathf.Clamp(fill.fillAmount * multiply, 8f, 1000f);
        playerGravity.AddGravity(Mathf.RoundToInt(value));
        playerSpeed.AddSpeed(Mathf.RoundToInt(value));

        fill.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable() => inputScript.onStart += Stop;

    private void OnDisable() => inputScript.onStart -= Stop;
}

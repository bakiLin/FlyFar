using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;
using YG;
using UnityEngine.SceneManagement;

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

    private Image fill;

    private Sequence sequence;

    private void Awake()
    {
        fill = transform.Find("Fill").GetComponent<Image>();

        sequence = DOTween.Sequence()
            .Append(fill.DOFillAmount(1f, 1f).SetEase(Ease.InCubic))
            .Append(fill.DOFillAmount(0f, 1f).SetEase(Ease.OutCubic))
            .SetLoops(-1);
    }

    private void Stop()
    {
        sequence.Kill();

        int index = SceneManager.GetActiveScene().buildIndex;
        float multiply = levelMultiply[YandexGame.savesData.GetPlayerLevel(index)[4]];
        int value = Mathf.RoundToInt(Mathf.Clamp(fill.fillAmount * multiply, 8f, 1000f));

        playerGravity.AddGravity(value);
        playerSpeed.AddSpeed(value);
        gameObject.SetActive(false);
    }

    private void OnEnable() => inputScript.onStart += Stop;

    private void OnDisable() => inputScript.onStart -= Stop;
}

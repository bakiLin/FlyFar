using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using TMPro;
using UnityEngine;
using Zenject;

public class DistanceManager : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private InputScript inputScript;

    [Inject]
    private TextManager textManager;

    [SerializeField]
    private RectTransform coinTransform;

    [SerializeField]
    private Vector2 startPosition, movePosition;

    public bool isAnimating { get; private set; }

    private TextMeshProUGUI distanceText;

    private int distance, num = 1;

    private CancellationTokenSource cts = new CancellationTokenSource();

    private void Awake()
    {
        distanceText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        inputScript.onStart += () => UpdateDistanceAsync().Forget();
        playerSpeed.onStop += cts.Cancel;
    }

    private async UniTaskVoid UpdateDistanceAsync()
    {
        while (!cts.IsCancellationRequested)
        {
            await UniTask.Delay(1000, cancellationToken: cts.Token);

            if (!cts.IsCancellationRequested)
            {
                distance += Mathf.RoundToInt(playerSpeed.speed.Value);
                distanceText.text = $"{distance} m";
                if (500 * num / distance < 1) GainBonusMoney().Forget();
            }
        }
    }

    private async UniTaskVoid GainBonusMoney()
    {
        isAnimating = true;
        num++;
        AudioManager.Instance.Play("wind", true);
        await DOTween.Sequence()
            .Append(coinTransform.DOAnchorPos(movePosition, 1f).SetEase(Ease.OutCubic))
            .Append(coinTransform.DOAnchorPos(startPosition, 1f).SetEase(Ease.InCubic));
        AudioManager.Instance.Play("coin", true);
        coinTransform.anchoredPosition = startPosition;
        textManager.SetCoin(100);
        isAnimating = false;
    }

    private void OnDestroy()
    {
        cts.Cancel();
    }
}

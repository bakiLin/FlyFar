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

    [Inject]
    private GameOver gameOver;

    [SerializeField]
    private RectTransform coinTransform;

    [SerializeField]
    private Vector2 position_1, position_2;

    private CancellationTokenSource cts = new CancellationTokenSource();

    private TextMeshProUGUI distanceText;

    private AudioManager audioManager;

    private int distance, num = 1;

    private Vector2 startPosition;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        distanceText = GetComponent<TextMeshProUGUI>();
        startPosition = coinTransform.position;
    }

    private async UniTaskVoid UpdateDistanceAsync()
    {
        while (!cts.IsCancellationRequested)
        {
            await UniTask.Delay(1000, cancellationToken: cts.Token);

            if (!cts.IsCancellationRequested)
            {
                distance += Mathf.RoundToInt(playerSpeed.speed.Value);

                distanceText.text = $"{distance.ToString()} m";

                GainBonusMoney().Forget();
            }
        }
    }

    private async UniTaskVoid GainBonusMoney()
    {
        if (distance / (500 * num) > 0)
        {
            gameOver.delay = true;
            audioManager.Play("fly", true);
            num++;
            await DOTween.Sequence()
                .Append(coinTransform.DOAnchorPos(position_1, 1f)
                    .SetEase(Ease.OutCubic))
                .Append(coinTransform.DOAnchorPos(position_2, 1f)
                    .SetEase(Ease.InOutCirc)
                    .OnComplete(() => {
                        audioManager.Play("coin", true);
                        coinTransform.anchoredPosition = startPosition; 
                    }));
            textManager.SetCoin(100);

            gameOver.delay = false;
        }
    }

    private void OnEnable()
    {
        inputScript.onStart += () => UpdateDistanceAsync().Forget();
        playerSpeed.onStop += cts.Cancel;
    }

    private void OnDestroy() => cts.Cancel();
}

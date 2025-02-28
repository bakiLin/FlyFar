using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class GameOver : MonoBehaviour
{
    [Inject]
    private TextManager textManager;

    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private RectTransform window;

    [SerializeField]
    private float Y, duration; 

    [SerializeField]
    private TextMeshProUGUI coinText, coinTotalText, multiplyText;

    [SerializeField]
    private float[] levelMultiply;

    private async void ResultWindow()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        int level = YandexGame.savesData.playerLevel[3];
        int money = Mathf.RoundToInt(textManager.coin * levelMultiply[level]);

        if (level > 0) multiplyText.text = $"x{levelMultiply[level]}";

        coinText.text = $"{money}";
        coinTotalText.text = $"Total: {YandexGame.savesData.money + money}";

        YandexGame.savesData.money += money;
        YandexGame.SaveProgress();

        window.DOAnchorPosY(Y, duration)
            .SetEase(Ease.OutQuart)
            .WithCancellation(cancellationToken: destroyCancellationToken)
            .Forget();
    }

    private void OnEnable()
    {
        playerSpeed.onStop += ResultWindow;
    }
}

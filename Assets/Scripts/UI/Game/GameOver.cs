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
    private TextMeshProUGUI coinText, coinTotalText;

    private async void ResultWindow()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        window.DOAnchorPosY(Y, duration)
            .SetEase(Ease.OutQuart);

        coinText.text = $"{textManager.coin}";
        coinTotalText.text = $"Total: {YandexGame.savesData.money + textManager.coin}";

        YandexGame.savesData.money += textManager.coin;
        YandexGame.SaveProgress();
    }

    private void OnEnable()
    {
        playerSpeed.onStop += ResultWindow;
    }
}

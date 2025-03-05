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
    private GameObject pauseButton;

    [SerializeField]
    private float[] levelMultiply;

    private RectTransform window;

    private TextMeshProUGUI coinText, coinTotalText, multiplyText;

    private void Awake()
    {
        window = GetComponent<RectTransform>();
        coinText = transform.Find("Coin (Text)").GetComponent<TextMeshProUGUI>();
        coinTotalText = transform.Find("Coin (Text)").GetComponent<TextMeshProUGUI>();
        multiplyText = transform.Find("Coin (Text)").GetComponent<TextMeshProUGUI>();
    }

    private void ResultWindow()
    {
        pauseButton.SetActive(false);

        int level = YandexGame.savesData.playerLevel[3];
        int money = Mathf.RoundToInt(textManager.coin * levelMultiply[level]);

        coinText.text = $"{money}";
        coinTotalText.text = $"Total: {YandexGame.savesData.money + money}";
        if (level > 0) multiplyText.text = $"x{levelMultiply[level]}";

        YandexGame.savesData.money += money;
        YandexGame.SaveProgress();

        window.DOAnchorPosY(-150f, 1f).SetEase(Ease.OutQuart);
    }

    private void OnEnable() => playerSpeed.onStop += ResultWindow;
}

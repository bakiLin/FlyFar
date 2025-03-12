using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [HideInInspector]
    public bool delay;

    private RectTransform window;

    private TextMeshProUGUI coinText, coinTotalText, multiplyText;

    private int level, money, sceneIndex;

    private void Awake()
    {
        window = GetComponent<RectTransform>();
        coinText = transform.Find("Coin (Text)").GetComponent<TextMeshProUGUI>();
        coinTotalText = transform.Find("Total (Text)").GetComponent<TextMeshProUGUI>();
        multiplyText = transform.Find("Multiply (Text)").GetComponent<TextMeshProUGUI>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private async void ResultWindow()
    {
        while (delay) await UniTask.DelayFrame(1);

        pauseButton.SetActive(false);

        level = YandexGame.savesData.GetPlayerLevel(sceneIndex)[3];
        money = Mathf.RoundToInt(textManager.coin * levelMultiply[level]);

        coinText.text = $"{money}";

        if (YandexGame.EnvironmentData.language == "ru") coinTotalText.text = $"Всего: {YandexGame.savesData.GetMoney(sceneIndex) + money}";
        else coinTotalText.text = $"Total: {YandexGame.savesData.GetMoney(sceneIndex) + money}";

        if (level > 0) multiplyText.text = $"x{levelMultiply[level]}";

        YandexGame.savesData.SetMoney(sceneIndex, money);
        YandexGame.SaveProgress();

        await window.DOAnchorPosY(-150f, 1f).SetEase(Ease.OutQuart);
    }

    public void GetReward()
    {
        coinText.text = $"{money * 2}";

        if (YandexGame.EnvironmentData.language == "ru") coinTotalText.text = $"Всего: {YandexGame.savesData.GetMoney(sceneIndex) + money}";
        else coinTotalText.text = $"Total: {YandexGame.savesData.GetMoney(sceneIndex) + money}";

        YandexGame.savesData.SetMoney(sceneIndex, money);
        YandexGame.SaveProgress();
    }

    private void OnEnable() => playerSpeed.onStop += ResultWindow;
}

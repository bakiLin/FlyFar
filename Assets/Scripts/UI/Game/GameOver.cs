using Cysharp.Threading.Tasks;
using DG.Tweening;
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

    [Inject]
    private DistanceManager distanceManager;

    [SerializeField]
    private GameObject pauseButton;

    [SerializeField]
    private float[] moneyLevel;

    private RectTransform window;

    private GameOverText gameOverText;

    private int level, money, sceneIndex;

    private void Awake()
    {
        window = GetComponent<RectTransform>();
        gameOverText = GetComponent<GameOverText>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        playerSpeed.onStop += ResultWindow;
    }

    private async void ResultWindow()
    {
        while (distanceManager.isAnimating) await UniTask.DelayFrame(10);

        pauseButton.SetActive(false);

        level = YandexGame.savesData.GetPlayerLevel(sceneIndex)[3];
        money = Mathf.RoundToInt(textManager.coin * moneyLevel[level]);
        gameOverText.SetText(YandexGame.EnvironmentData.language, money, YandexGame.savesData.GetMoney(sceneIndex) + money, moneyLevel[level]);

        YandexGame.savesData.SetMoney(sceneIndex, money);
        YandexGame.SaveProgress();

        window.DOAnchorPosY(-150f, 1f).SetEase(Ease.OutQuart);
    }

    public void GetReward()
    {
        gameOverText.SetText(YandexGame.EnvironmentData.language, money * 2, YandexGame.savesData.GetMoney(sceneIndex) + money, moneyLevel[level]);
        YandexGame.savesData.SetMoney(sceneIndex, money);
        YandexGame.SaveProgress();
    }
}

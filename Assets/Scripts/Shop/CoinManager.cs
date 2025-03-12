using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText, adText;

    [SerializeField]
    private int[] reward;

    private int sceneIndex;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        UpdateCoinText();
    }

    public void GetReward()
    {
        int money = reward[YandexGame.savesData.bonusLevel];
        YandexGame.savesData.SetMoney(sceneIndex, money);
        YandexGame.SaveProgress();
        UpdateCoinText();
    }

    public void SetMoney()
    {
        if (YandexGame.EnvironmentData.language == "ru")
            adText.text = $"{reward[YandexGame.savesData.bonusLevel]} монет за рекламу?";
        else
            adText.text = $"{reward[YandexGame.savesData.bonusLevel]} coins for and AD?";
    }

    public void UpdateCoinText() => coinText.text = YandexGame.savesData.GetMoney(sceneIndex).ToString();
}

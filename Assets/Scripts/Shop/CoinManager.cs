using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using YG;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText, bonusText;

    [SerializeField]
    private int[] reward;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinText.text = YandexGame.savesData.money.ToString();
    }

    public void GetReward()
    {
        int money = reward[YandexGame.savesData.bonusLevel];
        YandexGame.savesData.money += money;
        YandexGame.SaveProgress();
        UpdateCoinText();
    }

    public void SetMoney()
    {
        bonusText.text = $"{reward[YandexGame.savesData.bonusLevel]} монет за рекламу?";
    }
}

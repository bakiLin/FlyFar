using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using YG;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinText.text = YandexGame.savesData.money.ToString();
    }
}

using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ShopButtonManager : MonoBehaviour
{
    [SerializeField]
    private SelectManager selectManager;

    [SerializeField]
    private TextMeshProUGUI coinText;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        SetCoinText();
    }

    public void SetCoinText()
    {
        coinText.text = YandexGame.savesData.money.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveColor(ItemData data)
    {
        if (data.locked)
        {
            if (data.Buy())
            {
                SetCoinText();
                selectManager.SetColor();
            }
        }
        else
        {
            data.SetData();
            selectManager.SetColor();
        }
    }

    public void SaveFace(ItemData data)
    {
        if (data.locked)
        {
            if (data.Buy())
            {
                SetCoinText();
                selectManager.SetFace();
            }
        }
        else
        {
            data.SetData();
            selectManager.SetFace();
        }
    }
}

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
    private EnemyDataManager enemyDataManager;

    [SerializeField]
    private TextMeshProUGUI coinText;

    [SerializeField]
    private CategoryData[] categories;

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

    public void Category(CategoryData data)
    {
        foreach (var c in categories) c.TurnOff();

        selectManager.SetCategory(data.TurnOn());
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

    public void SetEnemyData(EnemyData data)
    {
        enemyDataManager.SetData(data.name, data.description, data.cost[0].ToString());
        selectManager.SetEnemy(data.image);
    }
}

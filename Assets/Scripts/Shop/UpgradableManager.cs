using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

public class UpgradableManager : MonoBehaviour
{
    [Inject]
    private SpriteManager spriteManager;

    [Inject]
    private CoinManager coinManager;

    [SerializeField]
    private TextMeshProUGUI titleText, descText, costText;

    [SerializeField]
    private Button button;

    [SerializeField]
    private Image[] images;

    private int sceneIndex;

    private void Awake() => sceneIndex = SceneManager.GetActiveScene().buildIndex;

    public void SetData(LevelItemData data)
    {
        titleText.text = data.title;
        descText.text = data.description;
        button.onClick.RemoveAllListeners();

        if (data.currentLevel != data.maxLevel)
        {
            SetCost(data);
            button.interactable = true;
            button.onClick.AddListener(() => Buy(data));
        }
        else
        {
            costText.text = "-";
            button.interactable = false;
            foreach (var image in images) image.sprite = spriteManager.filledSlot;
        }
    }

    private void SetCost(LevelItemData data)
    {
        if (data.maxLevel != data.currentLevel)
        {
            costText.text = data.cost[data.currentLevel].ToString();

            for (int i = 0; i < images.Length; i++)
            {
                if (data.currentLevel > i) images[i].sprite = spriteManager.filledSlot;
                else images[i].sprite = spriteManager.emptySlot;
            }
        }
        else
        {
            costText.text = "-";
            button.interactable = false;
            foreach (var image in images) image.sprite = spriteManager.filledSlot;
        }
    }

    private void Buy(LevelItemData data)
    {
        if (data.maxLevel > data.currentLevel && 
            YandexGame.savesData.GetMoney(sceneIndex) > data.cost[data.currentLevel])
        {
            YandexGame.savesData.SetMoney(sceneIndex, -data.cost[data.currentLevel]);

            if (data.currentLevel + 1 > YandexGame.savesData.bonusLevel)
                YandexGame.savesData.bonusLevel = data.currentLevel + 1;

            data.UpdateLevel();
            coinManager.UpdateCoinText();
            SetCost(data);
        }
    }
}

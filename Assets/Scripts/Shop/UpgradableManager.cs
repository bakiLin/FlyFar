using TMPro;
using UnityEngine;
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

    public void SetData(LevelItemData data)
    {
        if (data.currentLevel != data.maxLevel)
        {
            titleText.text = data.title;
            descText.text = data.description;

            SetCost(data);

            button.interactable = true;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => Buy(data));
        }
        else
        {
            titleText.text = data.title;
            descText.text = data.description;
            costText.text = "MAX";

            button.interactable = false;
            button.onClick.RemoveAllListeners();

            foreach (var image in images) image.sprite = spriteManager.filledSlot;
        }
    }

    private void SetCost(LevelItemData data)
    {
        costText.text = data.cost[data.currentLevel].ToString();

        for (int i = 0; i < images.Length; i++)
        {
            if (data.currentLevel > i) images[i].sprite = spriteManager.filledSlot;
            else images[i].sprite = spriteManager.emptySlot;
        }
    }

    private void Buy(LevelItemData data)
    {
        if (data.maxLevel > data.currentLevel && YandexGame.savesData.money > data.cost[data.currentLevel])
        {
            YandexGame.savesData.money -= data.cost[data.currentLevel];

            if (data.currentLevel + 1 > YandexGame.savesData.bonusLevel)
                YandexGame.savesData.bonusLevel = data.currentLevel + 1;

            data.UpdateLevel();
            coinManager.UpdateCoinText();
            SetCost(data);
        }
    }
}

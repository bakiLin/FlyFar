using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class LevelItemDataManager : MonoBehaviour
{
    [System.Serializable]
    public class LevelItem
    {
        public TextMeshProUGUI title, description, costText;
        public Button button;
        public Image[] slots;
    }

    [Inject]
    private CoinManager coinManager;

    [SerializeField]
    private LevelItem[] levelItems;

    [SerializeField]
    private Sprite emptySprite, boughtSprite, closedSprite;

    private void SetCost(LevelItemData data, LevelItem page)
    {
        for (int i = 0; i < page.slots.Length; i++)
        {
            if (data.lvlCurrent > i) page.slots[i].sprite = boughtSprite;
            else if (data.lvlMax > i) page.slots[i].sprite = emptySprite;
            else page.slots[i].sprite = closedSprite;
        }

        if (data.lvlCurrent != data.lvlMax)
            page.costText.text = data.cost[data.lvlCurrent].ToString();
        else
            page.costText.text = "MAX";
    }

    public void SetData(LevelItemData data)
    {
        var page = new LevelItem();

        if (data.GetType().Name == "EnemyData") page = levelItems[0];
        else page = levelItems[1];

        page.title.text = data.name;
        page.description.text = data.description;

        page.button.interactable = true;
        page.button.onClick.RemoveAllListeners();
        page.button.onClick.AddListener(() =>
        {
            if (data.lvlCurrent != data.lvlMax)
            {
                if (YandexGame.savesData.money > data.cost[data.lvlCurrent])
                {
                    YandexGame.savesData.money -= data.cost[data.lvlCurrent];

                    coinManager.UpdateCoinText();

                    data.UpdateLevel();

                    SetCost(data, page);
                }
            }
        });

        SetCost(data, page);
    }
}

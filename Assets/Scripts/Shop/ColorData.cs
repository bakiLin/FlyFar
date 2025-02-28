using UnityEngine.UI;
using YG;

public class ColorData : CosmeticItemData
{
    protected override void Select()
    {
        if (!YandexGame.savesData.colorUnlocked.Contains(id))
        {
            if (YandexGame.savesData.money > cost)
            {
                YandexGame.savesData.money -= cost;
                YandexGame.savesData.colorUnlocked.Add(id);
                YandexGame.savesData.color = id;
                YandexGame.SaveProgress();

                base.Select();
            }
        }
        else
        {
            YandexGame.savesData.color = id;
            YandexGame.SaveProgress();

            imageManager.SetBorders(GetComponent<Image>());
        }
    }
}

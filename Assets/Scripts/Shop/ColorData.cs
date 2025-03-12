using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;

public class ColorData : CosmeticItemData
{
    protected override void Select()
    {
        if (!YandexGame.savesData.colorUnlocked.Contains(id))
        {
            int index = SceneManager.GetActiveScene().buildIndex;

            if (YandexGame.savesData.GetMoney(index) > cost)
            {
                YandexGame.savesData.SetMoney(index, -cost);
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

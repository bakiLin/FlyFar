using UnityEngine.UI;
using YG;

public class FaceData : CosmeticItemData
{
    protected override void Select()
    {
        if (!YandexGame.savesData.faceUnlocked.Contains(id))
        {
            if (YandexGame.savesData.money > cost)
            {
                YandexGame.savesData.money -= cost;
                YandexGame.savesData.faceUnlocked.Add(id);
                YandexGame.savesData.face = id;
                YandexGame.SaveProgress();

                base.Select();
            }
        }
        else
        {
            YandexGame.savesData.face = id;
            YandexGame.SaveProgress();

            imageManager.SetBorders(GetComponent<Image>());
        }
    }
}

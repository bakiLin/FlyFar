using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class FaceData : CosmeticItemData
{
    protected override void Select()
    {
        if (!YandexGame.savesData.faceUnlocked.Contains(id))
        {
            int index = SceneManager.GetActiveScene().buildIndex;

            if (YandexGame.savesData.GetMoney(index) > cost)
            {
                YandexGame.savesData.SetMoney(index, -cost);
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

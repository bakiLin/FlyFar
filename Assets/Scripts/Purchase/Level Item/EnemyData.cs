using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using YG;

public class EnemyData : LevelItemData
{
    private async void Awake()
    {
        image = GetComponent<Image>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        if (id + 1 > YandexGame.savesData.enemyLevel.Count)
        {
            YandexGame.savesData.enemyLevel.Add(lvlCurrent);
            YandexGame.SaveProgress();
        }
        else
        {
            lvlCurrent = YandexGame.savesData.enemyLevel[id];
        }
    }

    public override void UpdateLevel()
    {
        lvlCurrent++;

        YandexGame.savesData.enemyLevel[id] = lvlCurrent;
        YandexGame.SaveProgress();
    }
}

using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using YG;

public class PlayerData : LevelItemData
{
    private async void Awake()
    {
        image = GetComponent<Image>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        lvlCurrent = YandexGame.savesData.playerLevel[id];
    }

    public override void UpdateLevel()
    {
        lvlCurrent++;

        YandexGame.savesData.playerLevel[id] = lvlCurrent;
        YandexGame.SaveProgress();
    }
}

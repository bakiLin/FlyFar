using YG;

public class PlayerData : LevelItemData
{
    protected override void Awake()
    {
        base.Awake();
        currentLevel = YandexGame.savesData.playerLevel[id];
    }

    public override void UpdateLevel()
    {
        base.UpdateLevel();
        YandexGame.savesData.playerLevel[id] = currentLevel;
        YandexGame.SaveProgress();
    }
}

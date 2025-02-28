using YG;

public class EnemyData : LevelItemData
{
    protected override void Awake()
    {
        base.Awake();
        currentLevel = YandexGame.savesData.enemyLevel[id];
    }

    public override void UpdateLevel()
    {
        base.UpdateLevel();
        YandexGame.savesData.enemyLevel[id] = currentLevel;
        YandexGame.SaveProgress();
    }
}

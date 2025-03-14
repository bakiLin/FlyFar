using UnityEngine.SceneManagement;
using YG;

public class PlayerData : LevelItemData
{
    private int sceneIndex;

    protected override void Awake()
    {
        base.Awake();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentLevel = YandexGame.savesData.GetPlayerLevel(sceneIndex)[id];
    }

    public override void UpdateLevel()
    {
        base.UpdateLevel();
        YandexGame.savesData.SetPlayerLevel(sceneIndex, id, currentLevel);
        YandexGame.SaveProgress();
    }
}

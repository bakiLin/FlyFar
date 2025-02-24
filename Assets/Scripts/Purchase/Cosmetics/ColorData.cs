using Cysharp.Threading.Tasks;
using YG;

public class ColorData : ItemData
{
    private async void Awake()
    {
        type = Type.Color;

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        locked = YandexGame.savesData.colorUnlocked.Contains(id) ? false : true;

        LockStatus();
    }

    public override void SetData()
    {
        YandexGame.savesData.color = id;
        YandexGame.savesData.colorUnlocked.Add(id);
        YandexGame.SaveProgress();
    }
}

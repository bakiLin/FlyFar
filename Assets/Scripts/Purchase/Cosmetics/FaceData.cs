using Cysharp.Threading.Tasks;
using YG;

public class FaceData : ItemData
{
    private async void Awake()
    {
        type = Type.Face;

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        locked = YandexGame.savesData.faceUnlocked.Contains(id) ? false : true;

        LockStatus();
    }

    public override void SetData()
    {
        YandexGame.savesData.face = id;
        YandexGame.savesData.faceUnlocked.Add(id);
        YandexGame.SaveProgress();
    }
}

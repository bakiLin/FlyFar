using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LevelItemData : MonoBehaviour
{
    public int id;

    public string title;

    public string description;

    public int maxLevel, currentLevel;

    public int[] cost;

    protected virtual async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        GetComponent<Button>().onClick.AddListener(() =>
        {
            GetComponentInParent<ImageManager>().SetBorders(GetComponent<Image>());
            GetComponentInParent<UpgradableManager>().SetData(this);
        });
    }

    public virtual void UpdateLevel()
    {
        currentLevel++;
    }
}

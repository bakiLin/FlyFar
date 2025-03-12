using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LevelItemData : MonoBehaviour
{
    public int id;

    public string titleEn, titleRu, descriptionEn, descriptionRu;

    public string title { get; private set; }

    public string description { get; private set; }

    public int maxLevel, currentLevel;

    public int[] cost;

    protected virtual async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        InitLang();

        GetComponent<Button>().onClick.AddListener(() =>
        {
            GetComponentInParent<ImageManager>().SetBorders(GetComponent<Image>());
            GetComponentInParent<UpgradableManager>().SetData(this);
        });
    }

    protected void InitLang()
    {
        if (YandexGame.EnvironmentData.language == "ru")
        {
            title = titleRu;
            description = descriptionRu;
        }
        else
        {
            title = titleEn;
            description = descriptionEn;
        }
    }

    public virtual void UpdateLevel() => currentLevel++;
}

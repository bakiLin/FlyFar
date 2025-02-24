using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class EnemyData : MonoBehaviour
{
    public new string name;

    public string description;

    public int lvlMax, lvlCurrent;

    public int[] cost;

    public Image image { get; private set; }

    private async void Awake()
    {
        image = GetComponent<Image>();

        while (YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        if (!YandexGame.savesData.enemyDictionary.ContainsKey(name))
        {
            YandexGame.savesData.enemyDictionary.Add(name, lvlCurrent);
        }
    }
}

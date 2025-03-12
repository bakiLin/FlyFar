using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class EnemyChangeLevel : MonoBehaviour
{
    [SerializeField]
    private float decrease;

    private EnemySpawner spawner;

    private async void Awake()
    {
        spawner = GetComponent<EnemySpawner>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        int level = YandexGame.savesData.enemyLevel[spawner.id];

        if (level > 0)
        {
            spawner.distance[0] -= decrease * level;
            spawner.distance[1] -= decrease * level;
        }
    }
}

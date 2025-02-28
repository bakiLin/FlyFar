using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner[] enemySpawners;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        foreach (var spawner in enemySpawners)
        {
            if (YandexGame.savesData.enemyLevel[spawner.id] > 0) spawner.enabled = true;
            else spawner.enabled = false;
        }
    }
}

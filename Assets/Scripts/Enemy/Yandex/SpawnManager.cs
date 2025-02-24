using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemySpawner;

    private EnemySpawner[] enemySpawners;

    private async void Awake()
    {
        enemySpawners = enemySpawner.GetComponents<EnemySpawner>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        List<int> list = YandexGame.savesData.enemyUnlocked;

        foreach (var spawner in enemySpawners)
        {
            if (!list.Contains(spawner.id)) 
                spawner.enabled = false;
        }
    }
}

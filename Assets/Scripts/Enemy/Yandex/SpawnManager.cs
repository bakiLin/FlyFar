using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using YG;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private EnemySpawner[] enemySpawners;

    private List<EnemySpawner> spawnerList = new List<EnemySpawner>();

    private CancellationTokenSource cts = new CancellationTokenSource();

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        foreach (var spawner in enemySpawners)
        {
            if (YandexGame.savesData.enemyLevel[spawner.id] > 0) spawner.enabled = true;
            else spawner.enabled = false;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            EnemySpawner spawner = transform.GetChild(i).GetComponent<EnemySpawner>();
            if (spawner.enabled) spawnerList.Add(spawner);
        }
    }

    private void Spawn()
    {
        foreach (var spawner in spawnerList) 
            spawner.SpawnAsync(cts.Token).Forget();
    }

    private void OnEnable()
    {
        inputScript.onStart += Spawn;
        playerSpeed.onStop += cts.Cancel;
    }

    private void OnDestroy() => cts.Cancel();
}

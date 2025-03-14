using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [Inject]
    private ObjectPooler objectPooler;

    [Inject]
    private PlayerSpeed playerSpeed;

    public int id;

    public string enemyTag;

    public float[] distance, yPosition;

    private Random random = new Random();

    private double delay;

    public async UniTaskVoid SpawnAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            delay = GetRandom(distance[0], distance[1]) / Mathf.Clamp(playerSpeed.speed.Value, 5f, 25f) * 1000;
            await UniTask.Delay((int)delay, cancellationToken: token);

            if (yPosition.Length > 1) objectPooler.Spawn(enemyTag, new Vector3(23f, GetRandom(yPosition[0], yPosition[1])));
            else objectPooler.Spawn(enemyTag, new Vector3(23f, yPosition[0]));
        }
    }

    private float GetRandom(float min, float max) => (float)((random.NextDouble() * (max - min)) + min);
}

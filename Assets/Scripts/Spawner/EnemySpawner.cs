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

    private Vector3 screenSize;

    private void Awake()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    public async UniTaskVoid SpawnAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            while (playerSpeed.speed.Value < playerSpeed.stopSpeed) await UniTask.DelayFrame(1);
            delay = GetRandom(distance[0], distance[1]) / Mathf.Clamp(playerSpeed.speed.Value, 5f, 25f) * 1000;
            await UniTask.Delay((int)delay, cancellationToken: token);

            if (yPosition.Length > 1) objectPooler.Spawn(enemyTag, new Vector3(screenSize.x + 2, GetRandom(yPosition[0], yPosition[1])));
            else objectPooler.Spawn(enemyTag, new Vector3(screenSize.x + 2, yPosition[0]));
        }
    }

    private float GetRandom(float min, float max) => (float)((random.NextDouble() * (max - min)) + min);
}

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

    [Inject]
    private InputScript inputScript;

    public int id;

    [SerializeField]
    private string enemyTag;

    public float[] distance;

    [SerializeField]
    private float[] yPosition;

    private Random random = new Random();

    private CancellationTokenSource cts;

    private void Awake() => cts = new CancellationTokenSource();

    private async UniTaskVoid SpawnAsync()
    {
        while (playerSpeed.speed.Value < 1f) await UniTask.DelayFrame(1);

        while (true)
        {
            double delay = GetRandom(distance[1], distance[0]) / Mathf.Clamp(playerSpeed.speed.Value, 5f, 25f) * 1000;

            await UniTask.Delay((int)delay, cancellationToken: cts.Token);

            if (yPosition.Length > 1)
                objectPooler.Spawn(enemyTag, new Vector3(15f, GetRandom(yPosition[0], yPosition[1])));
            else
                objectPooler.Spawn(enemyTag, new Vector3(15f, yPosition[0]));
        }
    }

    private float GetRandom(float min, float max)
    {
        double range = max - min;
        double value = (random.NextDouble() * range) + min;
        return (float)value;
    }

    private void OnEnable()
    {
        inputScript.onStart += () => { SpawnAsync().Forget(); };
        playerSpeed.onStop += () => { cts?.Cancel(); };
    }

    private void OnDisable() => cts?.Cancel();

    private void OnDestroy() => cts?.Cancel();
}

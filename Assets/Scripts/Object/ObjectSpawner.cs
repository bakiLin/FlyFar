using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObjectSpawner : MonoBehaviour
{
    [Inject]
    private Pooler pooler;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private float[] timeToSpawn, spawnBorder;

    private Random random = new Random();
    private float time;
    private bool spawn;

    private void Update()
    {
        if (spawn)
        {
            if (time >= 0)
                time -= Time.deltaTime;
            else
            {
                Vector2 position = new Vector2 (12f, RandomValue(spawnBorder));
                pooler.Spawn(itemName, position, transform);
                time = RandomValue(timeToSpawn);
            }
        }
    }

    public void IsSpawn(bool state) => spawn = state;

    private float RandomValue(float[] arr) => (float) random.NextDouble() * (arr[1] - arr[0]) + arr[0];
}
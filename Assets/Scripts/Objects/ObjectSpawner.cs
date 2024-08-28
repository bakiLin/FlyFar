using UnityEngine;
using Zenject;

public class ObjectSpawner : ObjectParent
{
    [Inject]
    private Pooler pooler;

    [SerializeField]
    private string objectName;

    [SerializeField]
    private float[] timeToSpawn = new float[2], spawnBorderY = new float[2];

    private float time;

    private void Start() => time = RandomValue(timeToSpawn);

    private void Update()
    {
        if (config.platformSpeed > 0)
        {
            if (time >= 0)
                time -= Time.deltaTime;
            else
            {
                float Y = RandomValue(spawnBorderY);
                pooler.Spawn(objectName, new Vector2(12f, Y));
                time = RandomValue(timeToSpawn);
            }
        }
    }
}

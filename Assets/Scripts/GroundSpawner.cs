using UnityEngine;
using Zenject;

public class GroundSpawner : MonoBehaviour
{
    [Inject]
    private Pooler pooler;

    [SerializeField]
    private Vector2 spawnPosition;

    private Transform lastPlatform;
    private Vector2 newSpawnPosition;
    private float platformScaleX;

    private void Start()
    {
        lastPlatform = pooler.Spawn("ground", new Vector2(spawnPosition.x, spawnPosition.y)).transform;
        platformScaleX = lastPlatform.localScale.x - 0.1f;
    }

    private void Update()
    {
        if (lastPlatform.position.x < 0f)
        {
            newSpawnPosition = new Vector2(lastPlatform.position.x + platformScaleX, spawnPosition.y);
            lastPlatform = pooler.Spawn("ground", newSpawnPosition).transform;
        }
    }
}

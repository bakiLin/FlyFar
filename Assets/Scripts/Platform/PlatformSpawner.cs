using UnityEngine;
using Zenject;

public class PlatformSpawner : MonoBehaviour
{
    [Inject]
    private Pooler pooler;

    [SerializeField]
    private Vector2 spawnPosition;

    private Transform lastPlatform;
    private float xScale;

    private void Start()
    {
        lastPlatform = pooler.Spawn("platform", spawnPosition, transform).transform;
        xScale = lastPlatform.localScale.x - 0.1f;
    }

    private void Update()
    {
        if (lastPlatform.position.x <= -1f)
        {
            spawnPosition.x = lastPlatform.position.x + xScale;
            lastPlatform = pooler.Spawn("platform", spawnPosition, transform).transform;
        }
    }
}

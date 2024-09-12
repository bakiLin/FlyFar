using UnityEngine;
using Zenject;

public class PlatformSpawner : MonoBehaviour
{
    [Inject]
    private Pooler pooler;

    [SerializeField]
    private Vector2 spawnPosition;

    private Transform lastPlatform;

    private void Start()
    {
        lastPlatform = pooler.Spawn("platform", spawnPosition, transform).transform;
    }

    private void FixedUpdate()
    {
        if (lastPlatform.position.x < 6f)
        {
            spawnPosition.x = lastPlatform.position.x + lastPlatform.localScale.x;
            lastPlatform = pooler.Spawn("platform", spawnPosition, transform).transform;
        }
    }
}

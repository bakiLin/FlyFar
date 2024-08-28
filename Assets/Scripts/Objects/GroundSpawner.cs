using UnityEngine;
using Zenject;

public class GroundSpawner : MonoBehaviour
{
    [Inject]
    private Pooler pooler;

    [SerializeField]
    private float platformPositionY;

    private Transform lastPlatform;
    private Vector2 spawnPosition;
    private float platformScaleX;

    private void Start()
    {
        spawnPosition = new Vector2(0f, platformPositionY);
        lastPlatform = pooler.Spawn("ground", spawnPosition).transform;
        platformScaleX = lastPlatform.localScale.x - 0.1f;
    }

    private void Update()
    {
        if (lastPlatform.position.x < -1f)
        {
            spawnPosition.x = lastPlatform.position.x + platformScaleX;
            lastPlatform = pooler.Spawn("ground", spawnPosition).transform;
        }
    }
}

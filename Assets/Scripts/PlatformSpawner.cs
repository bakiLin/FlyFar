using UnityEngine;
using Zenject;

public class PlatformSpawner : MonoBehaviour
{
    [Inject]
    private Pooler pooler;

    private GameObject lastPlatform;
    private float xScale;

    private const float yPosition = -4.5f;
    private const float xPosition = 2f;

    private void Start()
    {
        lastPlatform = pooler.Spawn("ground", new Vector2(xPosition, yPosition), Quaternion.identity);
        xScale = lastPlatform.transform.localScale.x - 0.1f;
    }

    private void Update()
    {
        if (lastPlatform.transform.position.x < 0f)
        {
            lastPlatform = pooler.Spawn("ground", 
                new Vector2(lastPlatform.transform.position.x + xScale, yPosition), 
                Quaternion.identity);
        }
    }
}

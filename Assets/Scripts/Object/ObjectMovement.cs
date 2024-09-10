using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObjectMovement : MonoBehaviour
{
    [Inject]
    private PlatformSpeed platformSpeed;

    private Random random = new Random();
    private float multiplier, speed;

    private void Start()
    {
        multiplier = (float) random.NextDouble();
        multiplier = Mathf.Clamp(multiplier, 0.6f, 0.7f);
    }

    void Update()
    {
        speed = platformSpeed.speed * multiplier;
        transform.Translate(Time.deltaTime * speed * Vector2.left);
    }
}

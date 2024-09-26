using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObjectMovement : MonoBehaviour
{
    [Inject]
    private PlatformSpeed platformSpeed;

    private Random random = new Random();
    private float multiplier, startSpeed, currentSpeed;

    private void Start()
    {
        multiplier = (float) random.NextDouble();
        multiplier = Mathf.Clamp(multiplier, 0.5f, 0.7f);
    }

    private void Update()
    {
        currentSpeed = platformSpeed.speed - startSpeed;
        transform.Translate(Time.deltaTime * currentSpeed * Vector2.left);
    }

    private void OnEnable() => startSpeed = Mathf.Clamp(platformSpeed.speed * multiplier, 5f, 20f);
}

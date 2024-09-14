using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObjectMovement : MonoBehaviour
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private ActionHolder spawnerState;

    private Random random = new Random();
    private float multiplier, startSpeed, currentSpeed;

    private void OnEnable()
    {
        multiplier = (float)random.NextDouble();
        multiplier = Mathf.Clamp(multiplier, 0.4f, 0.7f);
        startSpeed = Mathf.Clamp(platformSpeed.speed * multiplier, 0f, 20f);
    }

    void Update()
    {
        currentSpeed = platformSpeed.speed - startSpeed;
        transform.Translate(Time.deltaTime * currentSpeed * Vector2.left);
    }
}

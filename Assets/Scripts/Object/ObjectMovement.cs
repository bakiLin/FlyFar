using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObjectMovement : MonoBehaviour
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private SpawnerState spawnerState;

    private Random random = new Random();
    private float multiplier, startSpeed, currentSpeed;

    void Update() => transform.Translate(Time.deltaTime * currentSpeed * Vector2.left);

    private void OnEnable()
    {
        multiplier = (float)random.NextDouble();
        multiplier = Mathf.Clamp(multiplier, 0.4f, 0.6f);
        startSpeed = Mathf.Clamp(platformSpeed.speed * multiplier, 0f, 20f);

        spawnerState.OnSpeedChange += ChangeCurrentSpeed;
    }

    private void OnDisable()
    {
        spawnerState.OnSpeedChange -= ChangeCurrentSpeed;
    }

    private void ChangeCurrentSpeed() => /*currentSpeed = platformSpeed.speed - startSpeed;*/ print("slow down");
}

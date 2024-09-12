using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour, ICollideable
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private SpawnerState spawnerState;

    private void Update()
    {
        transform.Translate(platformSpeed.speed * Time.deltaTime * Vector2.left, Space.World);
    }

    public float Collide()
    {
        float jumpForce = platformSpeed.speed / 2;
        spawnerState.ChangeSpeed();

        if (platformSpeed.speed > 2f) platformSpeed.speed -= platformSpeed.speed / 5;
        else
        {
            platformSpeed.speed = 0f;
            playerGravity.enabled = false;
            spawnerState.ChangeRunState();
        }

        return jumpForce;
    }
}

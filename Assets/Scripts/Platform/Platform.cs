using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour, ICollideable
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private ActionHolder actionHolder;

    private void Update()
    {
        transform.Translate(platformSpeed.speed * Time.deltaTime * Vector2.left, Space.World);
    }

    public void Collide()
    {
        float jumpForce = platformSpeed.speed / 2;

        actionHolder.HitGround();

        if (platformSpeed.speed > 2f) 
            platformSpeed.speed -= platformSpeed.speed / 5;
        else
        {
            platformSpeed.speed = 0f;
            playerGravity.enabled = false;
            actionHolder.ChangeRunState();
        }

        playerGravity.SetGravity(jumpForce);
    }
}

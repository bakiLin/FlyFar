using UnityEngine;
using Zenject;

public class Bomb : MonoBehaviour, ICollideable
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    private float speed;

    private void Update()
    {
        speed = Mathf.Clamp(platformSpeed.speed, 0f, 20f);
        transform.Translate(Time.deltaTime * speed * Vector2.left, Space.World);
    }

    public void Collide()
    {
        playerGravity.SetGravity(15f);
        gameObject.SetActive(false);
    }
}

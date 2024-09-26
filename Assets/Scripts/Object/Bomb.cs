using UnityEngine;
using Zenject;

public class Bomb : MonoBehaviour, ICollideable
{
    [Inject]
    private PlatformSpeed platformSpeed;

    private float speed;

    private void Update()
    {
        speed = Mathf.Clamp(platformSpeed.speed, 0f, 15f);
        transform.Translate(Time.deltaTime * speed * Vector2.left);
    }

    public float Collide()
    {
        gameObject.SetActive(false);
        return 15f;
    }
}

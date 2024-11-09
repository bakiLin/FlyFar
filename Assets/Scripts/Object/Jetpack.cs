using UnityEngine;
using Zenject;

public class Jetpack : MonoBehaviour, ICollideable
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private PlayerGravity playerGravity; 

    private float speed, time = 3f;
    private bool flying = false;

    private void Update()
    {
        if (flying)
        {
            time -= Time.deltaTime;

            if (time < 0f)
            {
                flying = false;
                playerGravity.enabled = true;
                playerGravity.SetGravity(15f);
                gameObject.SetActive(false);
            }
        }
        else
        {
            speed = Mathf.Clamp(platformSpeed.speed, 0f, 20f);
            transform.Translate(Time.deltaTime * speed * Vector2.left, Space.World);
        }
    }

    public void Collide()
    {
        playerGravity.SetGravity(0f);
        playerGravity.enabled = false;
        flying = true;
    }
}

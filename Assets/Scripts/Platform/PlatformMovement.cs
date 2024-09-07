using UnityEngine;
using Zenject;

public class PlatformMovement : MonoBehaviour
{
    [Inject]
    protected PlatformSpeed platformSpeed;

    private void Update()
    {
        transform.Translate(platformSpeed.speed * Time.deltaTime * Vector2.left, Space.World);
    }
}

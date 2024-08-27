using UnityEngine;
using Zenject;

public class GroundPlatform : MonoBehaviour
{
    [Inject]
    private Launcher launcher;

    void Update()
    {
        transform.Translate(launcher.platformSpeed * Time.deltaTime * Vector2.left);
    }
}

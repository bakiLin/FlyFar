using UnityEngine;
using Zenject;

public class Launcher : MonoBehaviour
{
    [Inject]
    private PlayerGravity playerGravity;

    [HideInInspector]
    public float platformSpeed;

    [SerializeField]
    private LaunchPowerScale launchPowerScale;

    private void Update()
    {
        if (platformSpeed > 0f)
        {
            platformSpeed -= Time.deltaTime;

            if (platformSpeed < 0f)
                platformSpeed = 0f;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                platformSpeed = 10f;
                float launchPower = launchPowerScale.StopPointer();
                playerGravity.Launch(launchPower);
            }
        }
    }
}

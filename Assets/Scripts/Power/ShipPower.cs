using System.Collections;
using UnityEngine;
using Zenject;

public class ShipPower : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private FlyPower flyPower;

    [SerializeField]
    private int time;

    private void OnEnable()
    {
        playerGravity.SwitchGravity();
        playerGravity.transform.position.Set(transform.position.x, transform.position.y + 0.6f, 0f);

        flyPower.enabled = false;

        StopAllCoroutines();
        StartCoroutine(PilotCoroutine());
    }

    private IEnumerator PilotCoroutine()
    {
        for (int i = 0; i < time; i++)
        {
            playerSpeed.AddSpeed(1f);

            yield return new WaitForSeconds(0.5f);
        }

        playerGravity.SwitchGravity();

        flyPower.enabled = true;

        gameObject.SetActive(false);
    }
}

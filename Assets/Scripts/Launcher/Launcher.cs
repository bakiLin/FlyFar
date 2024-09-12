using System;
using UnityEngine;
using Zenject;

public class Launcher : MonoBehaviour
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private SpawnerState spawnerState;

    [SerializeField]
    private float[] xBorder;

    [SerializeField]
    private float speed;

    private Vector2 moveDirection;

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) StopPointer();
        
        if (transform.position.x <= xBorder[0]) moveDirection.x = speed;
        else if (transform.position.x >= xBorder[1]) moveDirection.x = -speed;

        transform.Translate(Time.deltaTime * moveDirection, Space.World);
    }

    private void StopPointer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        LaunchPower launchPower = hit.collider.GetComponent<LaunchPower>();

        platformSpeed.speed = launchPower.platfSpeed;
        playerGravity.enabled = true;
        playerGravity.SetGravity(launchPower.jumpPower);
        spawnerState.ChangeRunState();
        transform.parent.gameObject.SetActive(false);
    }
}

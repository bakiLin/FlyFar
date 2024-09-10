using System;
using UnityEngine;
using Zenject;

public class Launcher : MonoBehaviour
{
    [Inject]
    private PlatformSpeed platformSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private float speed;

    public Action onStart;

    private Vector2 moveDirection;
    private float offset;

    private void Start() => offset -= transform.position.x;

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) StopPointer();
        
        if (transform.position.x <= -offset) moveDirection.x = speed;
        else if (transform.position.x >= offset) moveDirection.x = -speed;

        transform.Translate(Time.deltaTime * moveDirection, Space.World);
    }

    private void StopPointer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        LaunchPower launchPower = hit.collider.GetComponent<LaunchPower>();

        platformSpeed.speed = launchPower.platfSpeed;
        playerGravity.Jump(launchPower.jumpPower);
        onStart?.Invoke();

        transform.parent.gameObject.SetActive(false);
    }
}

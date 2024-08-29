using UnityEngine;
using Zenject;

public class LaunchBar : MonoBehaviour
{
    [Inject]
    private Config config;

    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private Transform pointer;

    [SerializeField]
    private float pointerSpeed, xMin, xMax;

    private Vector2 moveDirection;
    private bool moveRight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(pointer.position, Vector2.up, 1f);

            if (hit.transform.name == "Green") SetBarValue(5f, 10f);
            else if (hit.transform.name == "Yellow") SetBarValue(10f, 15f);
            else if (hit.transform.name == "Red") SetBarValue(15f, 20f);

            gameObject.SetActive(false);
        }
        else
        {
            if (pointer.position.x <= xMin) moveRight = true;
            if (pointer.position.x >= xMax) moveRight = false;

            moveDirection = moveRight ? Vector2.right : Vector2.left;
            pointer.transform.Translate(pointerSpeed * Time.deltaTime * moveDirection, Space.World);
        }
    }

    private void SetBarValue(float platformSpeed, float jumpPower)
    {
        config.platformSpeed = platformSpeed;
        playerGravity.SetUpForce(jumpPower);
    }
}

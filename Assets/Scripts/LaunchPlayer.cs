using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight, timeToMaxHeight;

    private Vector2 moveDirection;

    private float velocity, gravity;

    private void Start()
    {
        float temp = jumpHeight * 2;
        velocity = temp / timeToMaxHeight;
        gravity = -temp / Mathf.Pow(timeToMaxHeight, 2f);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if (!hit)
        {
            if (moveDirection.y > gravity)
                moveDirection.y += gravity * Time.deltaTime;
        }
        else
            moveDirection.y = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
            moveDirection.y = velocity;

        transform.Translate(Time.deltaTime * moveDirection, Space.World);
    }
}

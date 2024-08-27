using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float negativeJumpHeight, timeToMaxHeight;

    private Vector2 moveDirection;
    private float gravity;

    private void Start()
    {
        gravity = (negativeJumpHeight * 2) / Mathf.Pow(timeToMaxHeight, 2f);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if (hit)
        {
            if (moveDirection.y < 0f)
                moveDirection.y = 0f;
        }
        else
        {
            if (moveDirection.y > gravity)
                moveDirection.y += gravity * Time.deltaTime;
        }

        transform.Translate(Time.deltaTime * moveDirection, Space.World);
    }

    public void Launch(float power) => moveDirection.y = power; 
}

using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float negativeJumpHeight, timeToMaxHeight;

    private Vector2 moveDirection;
    private float gravity;
    private int colls;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gravity = (negativeJumpHeight * 2) / Mathf.Pow(timeToMaxHeight, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colls++;

        //if (collision.collider.IsTouchingLayers(groundLayer - 1))
        //{
        //    moveDirection.y = 10f;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision) => colls--;

    private void Update()
    {
        if (colls > 0)
        {
            if (moveDirection.y < 0f)
                moveDirection.y = 0f;
        }
        else
        {
            if (moveDirection.y > gravity)
                moveDirection.y += gravity * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection;
    }

    public void Launch(float power) => moveDirection.y = power; 
}

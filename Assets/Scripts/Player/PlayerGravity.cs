using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight, timeToMaxHeight;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float gravity;
    private int colls;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start() => gravity -= (jumpHeight * 2) / Mathf.Pow(timeToMaxHeight, 2f);

    private void Update()
    {
        if (colls < 1 && moveDirection.y > gravity)
            moveDirection.y += gravity * Time.deltaTime;
        else if (colls > 0 && moveDirection.y < 0f)
            moveDirection.y = 0f;
    }

    private void FixedUpdate() => rb.velocity = moveDirection;

    public void SetUpForce(float power) => moveDirection.y = power;

    public void SetColls(int num) => colls += num;
}

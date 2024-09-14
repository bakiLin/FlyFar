using UnityEngine;
using Zenject;

public class PlayerGravity : MonoBehaviour
{
    [Inject]
    private ActionHolder actionHolder;

    [Inject]
    private PlatformSpeed platformSpeed;

    [SerializeField]
    private float gravity;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float multiplier;
    private bool grounded;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start() => ChangeGravity();

    private void Update()
    {
        if (!grounded)
        {
            if (moveDirection.y > gravity)
                moveDirection.y += Time.deltaTime * gravity * multiplier;
        }
        else
        {
            if (moveDirection.y < 0f)
                moveDirection.y = 0f;
        }
    }

    private void FixedUpdate() => rb.velocity = moveDirection;

    public void IsGrounded(bool state) => grounded = state;

    public void SetGravity(float value) => moveDirection.y = value;

    private void OnEnable() => actionHolder.OnChangeSpeed += ChangeGravity;

    private void OnDisable() => actionHolder.OnChangeSpeed -= ChangeGravity;

    private void ChangeGravity()
    {
        multiplier = 1 - ((platformSpeed.speed - 10f) / (25f - 10f) * 0.4f);
        multiplier = Mathf.Clamp(multiplier, 0.6f, 1f);
    }
}

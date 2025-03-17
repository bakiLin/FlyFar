using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float[] jumpMultiply;

    private Rigidbody2D rb;

    private float multiply;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        int index = SceneManager.GetActiveScene().buildIndex;
        multiply = jumpMultiply[YandexGame.savesData.GetPlayerLevel(index)[2]];
    }

    public void SwitchGravity()
    {
        rb.linearVelocityY = 0f;
        rb.gravityScale = rb.gravityScale.Equals(1) ? 0 : 1;
    }

    public void AddGravity(float value)
    {
        if (rb.gravityScale == 1) rb.linearVelocityY = value;
    }

    public void Bounce(float value)
    {
        if (rb.gravityScale == 1 && value > rb.linearVelocityY) rb.linearVelocityY = value * multiply;
    }
}

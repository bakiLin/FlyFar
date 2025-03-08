using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private float[] jumpMultiply;

    private Rigidbody2D rb;

    private float multiply;

    private async void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        int level = YandexGame.savesData.playerLevel[2];

        multiply = jumpMultiply[level];
    }

    public void AddGravity(float value)
    {
        if (rb.gravityScale == 1) rb.linearVelocityY = value;
    }

    public void Bounce(float value)
    {
        if (rb.gravityScale == 1 && value > rb.linearVelocityY) rb.linearVelocityY = value * multiply;
    }

    public void SwitchGravity()
    {
        rb.linearVelocityY = 0f;
        rb.gravityScale = rb.gravityScale.Equals(1) ? 0 : 1;
    }
}

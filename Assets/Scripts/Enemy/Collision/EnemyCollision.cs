using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    protected float jumpForce;

    [SerializeField]
    protected int score;

    protected Animator animator;

    protected bool isTriggered;

    protected virtual void Awake() => animator = GetComponent<Animator>();

    public virtual void Deactivate()
    {
        isTriggered = false;
        gameObject.SetActive(false);
    }

    public virtual (float, int) Collide()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            animator?.SetTrigger("Death");
            return (jumpForce, score);
        }

        return (0, 0);

    }
}

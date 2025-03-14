using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    protected float jumpForce;

    [SerializeField]
    protected int score;

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual float Collide()
    {
        enabled = false;

        animator.SetTrigger("Death");

        return jumpForce;
    }

    public int Score() => score;
}

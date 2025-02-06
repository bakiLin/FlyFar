using UnityEngine;

public class MouseCollision : MonoBehaviour, IEnemyCollision
{
    [SerializeField]
    private float jumpForce;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public float CollisionBehavior()
    {
        animator.SetTrigger("Death");

        return jumpForce;
    }

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}

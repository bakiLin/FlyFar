using DG.Tweening;
using UnityEngine;

public class BeeCollision : MonoBehaviour, IEnemyCollision
{
    [SerializeField]
    private float jumpForce;

    private Animator animator;

    private EnemyMovement enemyMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        enemyMovement = GetComponent<EnemyMovement>();
    }

    public float CollisionBehavior()
    {
        enemyMovement.enabled = false;

        transform.DOMoveY(-3f, 5f)
            .SetSpeedBased()
            .SetEase(Ease.Linear);

        animator.SetTrigger("Death");

        return jumpForce;
    }

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        enemyMovement.enabled = true;
    }
}

using UnityEngine;

public class ShipCollision : EnemyCollision
{
    private SpriteRenderer spriteRenderer;

    private EnemyMovement enemyMovement;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        enemyMovement = GetComponent<EnemyMovement>();
    }

    public override float Collide()
    {
        spriteRenderer.enabled = false;
        enemyMovement.enabled = false;

        transform.GetChild(0).gameObject.SetActive(true);

        return 0;
    }
}

using DG.Tweening;

public class BeeCollision : EnemyCollision
{
    public override (float, int) Collide()
    {
        transform.DOMoveY(-3f, 5f)
            .SetSpeedBased()
            .SetEase(Ease.Linear);

        return base.Collide();
    }
}

using DG.Tweening;

public class SpiderCollision : EnemyCollision
{
    public override float Collide()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + 0.5f, 0.3f).SetEase(Ease.OutCubic))
            .Append(transform.DOMoveY(transform.position.y, 0.3f).SetEase(Ease.InQuad));

        return base.Collide();
    }
}

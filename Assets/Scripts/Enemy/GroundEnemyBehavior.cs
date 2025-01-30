using UnityEngine;

public class GroundEnemyBehavior : MonoBehaviour, IEnemyCollisionBehavior
{
    [SerializeField]
    private float jumpForce;

    public float CollisionBehavior()
    {
        gameObject.SetActive(false);

        return jumpForce;
    }
}

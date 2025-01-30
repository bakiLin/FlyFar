using UnityEngine;

public class SkyEnemyCollisionBehavior : MonoBehaviour, IEnemyCollisionBehavior
{
    [SerializeField]
    private float jumpForce;

    public float CollisionBehavior()
    {
        gameObject.SetActive(false);

        return jumpForce;
    }
}

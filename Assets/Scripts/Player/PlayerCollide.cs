using UnityEngine;
using Zenject;

public class PlayerCollide : MonoBehaviour
{
    [Inject]
    private ActionHolder actionHolder;

    private PlayerGravity playerGravity;
    private bool checkCollisions;

    private void Awake() => playerGravity = GetComponent<PlayerGravity>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkCollisions)
        {
            var hitObject = collision?.collider.GetComponent<ICollideable>();
            if (hitObject != null) hitObject.Collide();
        }
    }

    private void OnEnable() => actionHolder.OnChangeRunState += ChangeCollisionState;

    private void OnDisable() => actionHolder.OnChangeRunState -= ChangeCollisionState;

    private void ChangeCollisionState() => checkCollisions = !checkCollisions;
}

using UnityEngine;
using Zenject;

public class PlayerCollide : MonoBehaviour
{
    [Inject]
    private ActionHolder spawnerState;

    private PlayerGravity playerGravity;
    private bool checkCollisions;

    private void Awake() => playerGravity = GetComponent<PlayerGravity>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkCollisions)
        {
            var temp = collision?.collider.GetComponent<ICollideable>();
            if (temp != null) playerGravity.SetGravity(temp.Collide());
        }
    }

    private void OnEnable() => spawnerState.OnChangeRunState += ChangeCollisionState;

    private void OnDisable() => spawnerState.OnChangeRunState -= ChangeCollisionState;

    private void ChangeCollisionState() => checkCollisions = !checkCollisions;
}

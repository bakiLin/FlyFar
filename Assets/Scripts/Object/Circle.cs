using UnityEngine;
using Zenject;

public class Circle : MonoBehaviour, ICollideable
{
    [Inject]
    private PlayerAbility playerAbility;

    public float Collide()
    {
        playerAbility.ResetAbility();
        gameObject.SetActive(false);
        return 15f;
    }
}

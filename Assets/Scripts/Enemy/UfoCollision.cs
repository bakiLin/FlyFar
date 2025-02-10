using UnityEngine;
using Zenject;

public class UfoCollision : MonoBehaviour, IEnemyCollision
{
    [Inject]
    private DiContainer diContainer;

    [SerializeField]
    private GameObject shipPrefab;

    private GameObject ship;

    private void Awake()
    {
        if (ship == null)
        {
            ship = diContainer.InstantiatePrefab(shipPrefab);
            ship.SetActive(false);
        }
    }

    public float CollisionBehavior()
    {
        ship.transform.position = transform.position;
        ship.SetActive(true);
        ship.GetComponent<ShipBehaviour>().Collision();

        gameObject.SetActive(false);

        return 0;
    }
}

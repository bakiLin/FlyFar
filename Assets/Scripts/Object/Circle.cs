using UnityEngine;

public class Circle : MonoBehaviour, ICollideable
{
    public float Collide()
    {
        gameObject.SetActive(false);
        return 15f;
    }
}

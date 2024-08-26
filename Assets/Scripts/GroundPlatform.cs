using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}

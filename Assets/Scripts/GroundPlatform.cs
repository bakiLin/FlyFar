using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPlatform;

    private static GroundPlatform instance;

    private bool spawned;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);

        if (transform.position.x <= 0 && !spawned)
        {
            spawned = true;
            Instantiate(groundPlatform, new Vector3(instance.transform.position.x + 20f, transform.position.y, 0f), Quaternion.identity);
        }

        if (transform.position.x <= -20)
            Destroy(this.gameObject);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class GroundPlatform : MonoBehaviour
{
    private static GroundPlatform instance;
    // Add last created platform into instance to spawn new platform right after

    [SerializeField]
    private GameObject groundPlatform;

    private bool spawned;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        print(instance);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);

        if (transform.position.x <= 0 && !spawned)
        {
            spawned = true;
            Instantiate(groundPlatform, new Vector3(transform.position.x + 20f, transform.position.y, 0f), Quaternion.identity);
        }
    }
}

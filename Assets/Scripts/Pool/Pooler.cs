using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pooler : MonoBehaviour
{
    [Inject]
    private DiContainer diContainer;

    public List<Pool> pools;

    private Dictionary<string, Queue<GameObject>> dict = new();

    private void Awake()
    {
        foreach (var pool in pools)
        {
            Queue<GameObject> q = new();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = diContainer.InstantiatePrefab(pool.prefab, pool.parent.transform);
                obj.SetActive(false);
                q.Enqueue(obj);
            }

            dict.Add(pool.tag, q);
        }
    }

    public GameObject Spawn(string tag, Vector3 position)
    {
        GameObject obj = dict[tag].Dequeue();

        obj.SetActive(true);
        obj.transform.position = position;

        dict[tag].Enqueue(obj);

        return obj;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public int size;
        public GameObject prefab;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    private void Start()
    {
        poolDict = new();

        foreach (var pool in pools)
        {
            Queue<GameObject> q = new();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                q.Enqueue(obj);
            }

            poolDict.Add(pool.tag, q);
        }
    }

    public GameObject Spawn(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject obj = poolDict[tag].Dequeue();

        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        poolDict[tag].Enqueue(obj);

        return obj;
    }
}

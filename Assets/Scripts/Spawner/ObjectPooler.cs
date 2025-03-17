using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int id;
        public string tag;
        public GameObject prefab;
        public int size;
        public Transform parent;
    }

    [Inject]
    private DiContainer diContainer;

    [SerializeField]
    private List<Pool> pools;

    [SerializeField]
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = diContainer.InstantiatePrefab(pool.prefab, pool.parent);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public void Spawn(string tag, Vector3 position)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject obj = poolDictionary[tag].Dequeue();
            obj.SetActive(false);
            obj.transform.position = position;
            obj.SetActive(true);
            poolDictionary[tag].Enqueue(obj);
        }
    }
}

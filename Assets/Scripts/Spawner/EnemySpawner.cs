using System.Collections;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [Inject]
    private ObjectPooler objectPooler;

    [SerializeField]
    private int minY, maxY;

    private Random random = new Random();

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(15f, random.Next(minY, maxY));

            Spawn(spawnPosition);

            yield return new WaitForSeconds(2f);
        }
    }

    private void Spawn(Vector3 position)
    {
        string tag = "enemy";

        if (objectPooler.poolDictionary.ContainsKey(tag))
        {
            GameObject obj = objectPooler.poolDictionary[tag].Dequeue();
            obj.transform.position = position;
            obj.SetActive(true);
            objectPooler.poolDictionary[tag].Enqueue(obj);
        }
    }
}

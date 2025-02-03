using System.Collections;
using UnityEngine;
using Zenject;
using Random = System.Random;

public abstract class EnemySpawner : MonoBehaviour
{
    [Inject]
    protected ObjectPooler objectPooler;

    [Inject]
    protected PlayerSpeed playerSpeed;

    [SerializeField]
    protected string enemyTag;

    [SerializeField]
    protected int distanceMin, distanceMax;

    protected Random random = new Random();

    protected virtual IEnumerator SpawnCoroutine() { yield return null; }

    public void StartSpawn() => StartCoroutine(SpawnCoroutine());

    protected void Spawn(Vector3 position)
    {
        if (objectPooler.poolDictionary.ContainsKey(enemyTag))
        {
            GameObject obj = objectPooler.poolDictionary[enemyTag].Dequeue();
            obj.SetActive(false);
            obj.transform.position = position;
            obj.SetActive(true);
            objectPooler.poolDictionary[enemyTag].Enqueue(obj);
        }
    }
}

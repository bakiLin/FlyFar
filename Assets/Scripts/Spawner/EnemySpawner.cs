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

    [Inject]
    protected InputScript inputScript;

    [SerializeField]
    protected string enemyTag;

    [SerializeField]
    protected double minDistance, maxDistance;

    protected Random random = new Random();

    protected virtual IEnumerator SpawnCoroutine() { yield return null; }

    protected void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

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

    protected void OnEnable()
    {
        inputScript.onStart += StartSpawn;
        playerSpeed.onStop += StopAllCoroutines;
    }

    protected void OnDisable()
    {
        inputScript.onStart -= StartSpawn;
        playerSpeed.onStop -= StopAllCoroutines;
    }
}

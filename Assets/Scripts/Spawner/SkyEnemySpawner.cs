using System.Collections;
using UnityEngine;
using Random = System.Random;

public class SkyEnemySpawner : EnemySpawner
{
    [SerializeField]
    private int minY, maxY;

    private Random random = new Random();

    protected override IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Vector3 spawnPosition = new Vector3(15f, random.Next(minY, maxY));

            Spawn(spawnPosition);

            float delay = enemyDistance / playerSpeed.GetSpeed();

            yield return new WaitForSeconds(delay);
        }
    }
}

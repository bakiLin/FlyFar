using System.Collections;
using UnityEngine;

public class SkyEnemySpawner : EnemySpawner
{
    [SerializeField]
    private int minY, maxY;

    protected override IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Vector3 spawnPosition = new Vector3(15f, random.Next(minY, maxY));

            Spawn(spawnPosition);

            yield return new WaitForSeconds(delay);
        }
    }
}

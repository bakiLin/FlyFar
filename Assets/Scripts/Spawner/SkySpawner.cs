using System.Collections;
using UnityEngine;

public class SkySpawner : EnemySpawner
{
    [SerializeField]
    private int minY, maxY;

    protected override IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            Vector3 spawnPosition = new Vector3(15f, random.Next(minY, maxY));

            Spawn(spawnPosition);

            double range = maxDistance - minDistance;
            double distance = (random.NextDouble() * range) + minDistance;
            double delay = distance / (playerSpeed.GetSpeed() * 0.8f);

            yield return new WaitForSeconds((float) delay);
        }
    }
}

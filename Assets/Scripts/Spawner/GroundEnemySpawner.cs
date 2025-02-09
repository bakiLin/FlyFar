using System.Collections;
using UnityEngine;

public class GroundEnemySpawner : EnemySpawner
{
    [SerializeField]
    private float positionY;

    protected override IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Spawn(new Vector3(15f, positionY));

            double range = (double) maxDelay - (double) minDelay;
            double value = random.NextDouble();
            double delay = (value * range) + minDelay;

            yield return new WaitForSeconds((float)delay);
        }
    }
}

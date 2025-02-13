using System.Collections;
using UnityEngine;

public class GroundSpawner : EnemySpawner
{
    [SerializeField]
    private float yPosition;

    protected override IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            Spawn(new Vector3(15f, yPosition));

            double range = maxDistance - minDistance;
            double distance = (random.NextDouble() * range) + minDistance;
            double delay = distance / playerSpeed.GetSpeed();

            yield return new WaitForSeconds((float) delay);
        }
    }
}

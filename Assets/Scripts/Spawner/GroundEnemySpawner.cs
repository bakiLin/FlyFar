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

            float delay = enemyDistance / playerSpeed.GetSpeed();

            yield return new WaitForSeconds(delay);
        }
    }
}

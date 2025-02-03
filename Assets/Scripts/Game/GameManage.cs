using UnityEngine;
using Zenject;

public class GameManage : MonoBehaviour
{
    [Inject]
    private PowerBarArrow powerBarArrow;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerCollision playerCollision;

    [Inject]
    private SkyEnemySpawner skyEnemySpawner;

    [Inject]
    private GroundEnemySpawner groundEnemySpawner;

    public void StartGame()
    {
        float powerBarValue = powerBarArrow.StopArrow();
        playerGravity.Jump(powerBarValue);
        playerSpeed.Jump(powerBarValue);

        playerCollision.isStarted = true;

        skyEnemySpawner.StartSpawn();
        groundEnemySpawner.StartSpawn();
    }

    public void StopGame()
    {
        playerCollision.isStarted = false;

        skyEnemySpawner.StopAllCoroutines();
        groundEnemySpawner.StopAllCoroutines();
    }
}

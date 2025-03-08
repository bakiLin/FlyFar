using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class CloudCollision : EnemyCollision
{
    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerParticleManager playerParticleManager;

    [Inject]
    private InputScript inputScript;

    [SerializeField]
    private float rideDuration;

    private ShipMovement shipMovement;

    protected override void Awake()
    {
        base.Awake();
        shipMovement = GetComponent<ShipMovement>();
    }

    public override float Collide()
    {
        shipMovement.Stop();
        playerGravity.SwitchGravity();
        playerParticleManager.StopFalling();

        transform.position = playerGravity.transform.position;

        RideAsync();

        return jumpForce;
    }

    private async void RideAsync()
    {
        inputScript.SwitchPower(false);

        for (int i = 0; i < rideDuration * 2; i++)
        {
            await UniTask.Delay(500);
            playerSpeed.AddSpeed(1f);
        }

        playerGravity.SwitchGravity();
        inputScript.SwitchPower(true);
        gameObject.SetActive(false);
    }
}

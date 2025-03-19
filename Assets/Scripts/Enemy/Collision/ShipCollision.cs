using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ShipCollision : EnemyCollision
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private InputScript inputScript;

    [Inject]
    private PlayerParticleManager playerParticleManager;

    [SerializeField]
    private int rideDuration;

    [SerializeField]
    private bool cloud;

    private GameObject ship;

    private bool isTriggered;

    protected override void Awake() => ship = transform.Find("Ship").gameObject;

    private void OnEnable() => Appearance(true);

    private void Appearance(bool state)
    {
        ship.SetActive(!state);
        if (!cloud) GetComponent<SpriteRenderer>().enabled = state;
        if (!state)
        {
            GetComponent<EvenSpeedMovement>().tween.Kill();
            GetComponent<VerticalMovement>()?.sequence.Kill();
        }
    }

    public override (float, int) Collide()
    {
        if (!isTriggered)
        {
            isTriggered = true;

            playerParticleManager.StopFalling();
            playerGravity.SwitchGravity();
            inputScript.SwitchPower(false);
            transform.position = new Vector3(playerGravity.transform.position.x, playerGravity.transform.position.y - 0.6f);
            Appearance(false);
            Pilot();

            return (0, score);
        }

        return (0, 0);
    }

    private async void Pilot()
    {
        for (int i = 0; i < rideDuration * 2; i++)
        {
            await UniTask.Delay(500);
            playerSpeed.AddSpeed(1f);
        }

        playerGravity.SwitchGravity();
        inputScript.SwitchPower(true);
        gameObject.SetActive(false);
        isTriggered = false;
    }
}

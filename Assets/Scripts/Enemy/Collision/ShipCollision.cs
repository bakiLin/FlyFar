using Cysharp.Threading.Tasks;
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

    [SerializeField]
    private int time;

    private bool called;

    private SpriteRenderer spriteRenderer;

    private ShipMovement shipMovement;

    private GameObject ship;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shipMovement = GetComponent<ShipMovement>();
        ship = transform.Find("Ship").gameObject;
    }

    private void Switch(bool state)
    {
        spriteRenderer.enabled = state;
        ship.SetActive(!state);
        if (!state) shipMovement.Stop();
    }

    private void OnEnable()
    {
        Switch(true);
        called = false;
    }

    public override float Collide()
    {
        if (!called)
        {
            playerGravity.SwitchGravity();

            Vector3 player = playerGravity.transform.position;
            transform.position = new Vector3(player.x, player.y - 0.6f);

            Switch(false);
            Pilot();

            called = true;
        }

        return jumpForce;
    }

    private async void Pilot()
    {
        inputScript.SwitchFlyPower(false);

        for (int i = 0; i < time * 2; i++)
        {
            await UniTask.Delay(500);

            playerSpeed.AddSpeed(1f);
        }

        playerGravity.SwitchGravity();

        inputScript.SwitchFlyPower(true);

        gameObject.SetActive(false);
    }
}

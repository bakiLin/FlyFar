using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField]
    private float cooldownTime, flyPower, maxFlyTime;

    private PlayerGravity playerGravity;
    private float cooldown, jumpTime;

    private void Awake() => playerGravity = GetComponent<PlayerGravity>();

    private void Update()
    {
        if (cooldown > 0f) 
            cooldown -= Time.deltaTime;
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                jumpTime = maxFlyTime;
                playerGravity.SetGravity(flyPower);
            }

            if (Input.GetKey(KeyCode.J))
            {
                if (jumpTime > 0f)
                {
                    jumpTime -= Time.deltaTime;
                    playerGravity.SetGravity(flyPower);
                }
                else
                    cooldown = cooldownTime;
            }

            if (Input.GetKeyUp(KeyCode.J))
                cooldown = cooldownTime;
        }
    }

    public void ResetAbility() => cooldown = cooldownTime;
}

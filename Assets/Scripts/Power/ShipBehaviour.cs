using System.Collections;
using UnityEngine;
using Zenject;

public class ShipBehaviour : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private UITextManager textManager;

    [Inject]
    private InputScript inputScript;

    [SerializeField]
    private int flyTime;

    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = playerSpeed.gameObject.GetComponent<Rigidbody2D>();
    }

    public void Collision()
    {
        playerRb.transform.position = new Vector3(transform.position.x, transform.position.y + 0.6f);
        playerRb.gravityScale = 0f;

        inputScript.enabled = false;

        StartCoroutine(CollisionCoroutine());
    }

    private IEnumerator CollisionCoroutine()
    {
        int time = 0;

        while (time < flyTime)
        {
            playerSpeed.SetSpeed(playerSpeed.GetSpeed() + 1f);
            textManager.SetSpeed(playerSpeed.GetSpeed());

            yield return new WaitForSeconds(0.5f);

            time++;
        }

        playerRb.gravityScale = 1f;

        transform.gameObject.SetActive(false);

        inputScript.enabled = true;
    }
}

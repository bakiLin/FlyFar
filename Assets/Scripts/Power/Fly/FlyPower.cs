using System.Collections;
using UnityEngine;
using Zenject;

public class FlyPower : MonoBehaviour
{
    [Inject]
    private UITextManager uiTextManager;

    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private int force, amount;

    public float time;

    private GameObject left, right;

    private void Awake()
    {
        uiTextManager.SetPower(amount);

        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;
    }

    private IEnumerator FlyCoroutine()
    {
        if (amount > 0)
        {
            amount -= 1;

            left.SetActive(true);
            right.SetActive(true);

            uiTextManager.SetPower(amount);

            yield return new WaitForSeconds(time / 2);

            playerGravity.AddGravity(force);

        }
    }

    public void Fly() => StartCoroutine(FlyCoroutine());
}

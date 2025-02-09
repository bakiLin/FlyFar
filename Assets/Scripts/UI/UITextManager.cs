using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class UITextManager : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private TextMeshProUGUI coinText, powerText, speedText;

    private int coin;

    public void SetCoin(int value)
    {
        coin += value;

        coinText.text = coin.ToString();
    }

    public void SetPower(int value)
    {
        powerText.text = value.ToString();
    }

    public void SetSpeed(float value)
    {
        speedText.text = value.ToString();
    }

    private IEnumerator StartSpeedCoroutine()
    {
        while (playerSpeed.GetSpeed() == 0)
            yield return null;

        SetSpeed(playerSpeed.GetSpeed());
    }

    private void StartSpeed() => StartCoroutine(StartSpeedCoroutine());

    private void OnEnable()
    {
        inputScript.onStart += StartSpeed;
    }

    private void OnDisable()
    {
        inputScript.onStart -= StartSpeed;
    }
}

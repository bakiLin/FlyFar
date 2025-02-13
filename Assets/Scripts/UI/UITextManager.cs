using TMPro;
using UnityEngine;
using Zenject;

public class UITextManager : MonoBehaviour
{
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

    public void SetPower(int value) => powerText.text = value.ToString();

    public void SetSpeed() => speedText.text = playerSpeed.GetSpeed().ToString();

    private void OnEnable()
    {
        playerSpeed.onChange += SetSpeed;
    }

    private void OnDisable()
    {
        playerSpeed.onChange -= SetSpeed;
    }
}

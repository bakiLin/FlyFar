using TMPro;
using UnityEngine;

public class UITextManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText, powerText;

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
}

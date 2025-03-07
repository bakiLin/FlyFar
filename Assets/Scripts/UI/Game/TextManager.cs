using TMPro;
using UnityEngine;
using Zenject;

public class TextManager : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private TextMeshProUGUI coinText, powerText, speedText;

    public int coin { get; private set; }

    public void SetCoin(int value)
    {
        coin += value;
        coinText.text = coin.ToString();
    }

    public void SetPower(int value)
    {
        powerText.text = value.ToString();
    }

    private void OnEnable()
    {
        playerSpeed.onChange += () => speedText.text = playerSpeed.speed.ToString();
        playerSpeed.onStop += () => speedText.text = "0"; 
    }
}

using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText, totalText, multiplyText;

    public void SetText(string lang, int money, int total, float multiplier)
    {
        coinText.text = $"{money}";
        totalText.text = lang.Equals("ru") ? $"Всего: {total}" : $"Total: {total}";
        if (multiplier > 1) multiplyText.text = $"x{multiplier}";
    }
}

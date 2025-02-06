using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score;

    public void SetScore(int value)
    {
        score += value;

        scoreText.text = score.ToString();
    }
}

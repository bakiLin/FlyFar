using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [SerializeField]
    private int score;

    public int GetScore() => score;
}

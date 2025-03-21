using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GroundCollision : MonoBehaviour
{
    [SerializeField]
    private float[] speedLoss;

    public float force;

    public float loss { get; private set; }

    private void Awake()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        loss = speedLoss[YandexGame.savesData.GetPlayerLevel(index)[1]];
    }
}

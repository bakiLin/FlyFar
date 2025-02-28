using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class GroundCollision : MonoBehaviour
{
    [SerializeField]
    private float[] speedLoss;

    public float force;

    public float multiply { get; private set; }

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.Delay(100);

        int level = YandexGame.savesData.playerLevel[1];

        multiply = speedLoss[level];
    }
}

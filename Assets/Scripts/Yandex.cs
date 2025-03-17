using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class Yandex : MonoBehaviour
{
    [SerializeField]
    private GameObject block;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);
        block.SetActive(false);
    }
}

using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;

public class PlayerAppearance : MonoBehaviour
{
    [SerializeField]
    private Sprite[] color, face;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        GetComponent<SpriteRenderer>().sprite = color[YandexGame.savesData.color];

        transform.Find("Face").GetComponent<SpriteRenderer>().sprite = face[YandexGame.savesData.face];
    }
}

using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;
using Zenject;

public class PlayerAppearance : MonoBehaviour
{
    [Inject]
    private SpriteManager spriteManager;

    [SerializeField]
    private SpriteRenderer faceSpriteRenderer;

    private SpriteRenderer spriteRenderer;

    private async void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        spriteRenderer.sprite = spriteManager.color[YandexGame.savesData.color];
        faceSpriteRenderer.sprite = spriteManager.face[YandexGame.savesData.face];
    }
}

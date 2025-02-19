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

        SetColor();
        SetFace();
    }

    private void SetColor()
    {
        int index = YandexGame.savesData.color;
        spriteRenderer.sprite = spriteManager.color[index];
    }

    private void SetFace()
    {
        int index = YandexGame.savesData.face;
        faceSpriteRenderer.sprite = spriteManager.face[index];
    }
}

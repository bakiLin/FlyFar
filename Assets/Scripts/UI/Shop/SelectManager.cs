using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    private Sprite selectSprite, regularSprite;

    [SerializeField]
    private Image[] category, color, face, enemy;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        SetColor();
        SetFace();
    }

    public void SetColor()
    {
        foreach (var c in color) c.sprite = regularSprite;

        int index = YandexGame.savesData.color;
        color[index].sprite = selectSprite;
    }

    public void SetFace()
    {
        foreach (var f in face) f.sprite = regularSprite;

        int index = YandexGame.savesData.face;
        face[index].sprite = selectSprite;
    }

    public void SetCategory(Image image)
    {
        foreach (var c in category) c.sprite = regularSprite;

        image.sprite = selectSprite;
    }

    public void SetEnemy(Image image)
    {
        foreach (var e in enemy) e.sprite = regularSprite;

        image.sprite = selectSprite;
    }
}

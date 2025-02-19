using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    private Sprite selectSprite, regularSprite;

    [SerializeField]
    private Image[] color;

    [SerializeField]
    private Image[] face;

    private async void Awake()
    {
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);

        SetColor();
        SetFace();
    }

    public void SetColor()
    {
        foreach (var c in color)
            c.sprite = regularSprite;

        int index = YandexGame.savesData.color;
        color[index].sprite = selectSprite;
    }

    public void SetFace()
    {
        foreach (var f in face)
            f.sprite = regularSprite;

        int index = YandexGame.savesData.face;
        face[index].sprite = selectSprite;
    }
}

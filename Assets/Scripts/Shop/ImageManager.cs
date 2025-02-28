using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class ImageManager : MonoBehaviour
{
    [Inject]
    private SpriteManager spriteManager;

    private Image[] images;

    private void Awake()
    {
        images = new Image[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            images[i] = transform.GetChild(i).GetComponent<Image>();
            images[i].sprite = spriteManager.commonBorder;
        }

        CosmeticItemData temp = GetComponentInChildren<CosmeticItemData>();

        if (temp)
        {
            if (temp.GetType() == typeof(ColorData)) images[YandexGame.savesData.color].sprite = spriteManager.selectedBorder;
            else images[YandexGame.savesData.face].sprite = spriteManager.selectedBorder;
        }
    }

    public void SetBorders(Image button)
    {
        foreach (var image in images) image.sprite = spriteManager.commonBorder;

        button.sprite = spriteManager.selectedBorder; 
    }
}

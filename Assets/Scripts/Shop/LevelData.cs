using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class LevelData : MonoBehaviour
{
    [Inject]
    private SpriteManager spriteManager;

    private Image[] images;

    private Button[] buttons;

    private async void Awake()
    {
        Init();
        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(1);
        SetSprite();
        SetButtons();
    }

    private void Init()
    {
        images = new Image[transform.childCount];
        buttons = new Button[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            images[i] = transform.GetChild(i).GetComponent<Image>();
            buttons[i] = transform.GetChild(i).GetComponent<Button>();
        }
    }

    private void SetSprite()
    {
        for (int i = 0; i < transform.childCount; i++)
            images[i].sprite = spriteManager.commonBorder;

        images[YandexGame.savesData.currentLevel].sprite = spriteManager.selectedBorder;
    }

    private void SetButtons()
    {
        buttons[0].onClick.AddListener(() => {
            YandexGame.savesData.currentLevel = 0;
            YandexGame.SaveProgress();
            SetSprite();
        });

        buttons[1].onClick.AddListener(() => {
            YandexGame.savesData.currentLevel = 1;
            YandexGame.SaveProgress();
            SetSprite();
        });
    }
}

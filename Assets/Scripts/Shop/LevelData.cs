using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

public class LevelData : MonoBehaviour
{
    [Inject]
    private SpriteManager spriteManager;

    private Image[] images;

    private Button[] buttons;

    private void Awake()
    {
        Init();
        SetSprite();
        SetButtons();
        if (YandexGame.savesData.lvl2Unlocked) Unlock();
    }

    private void Unlock()
    {
        buttons[1].transform.Find("Block")?.gameObject.SetActive(false);
        buttons[1].transform.Find("Cost")?.gameObject.SetActive(false);
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
        for (int i = 0; i < transform.childCount; i++) images[i].sprite = spriteManager.commonBorder;
        images[YandexGame.savesData.currentLevel].sprite = spriteManager.selectedBorder;
    }

    private void SetButtons()
    {
        buttons[0].onClick.AddListener(() => {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                YandexGame.savesData.currentLevel = 0;
                YandexGame.SaveProgress();
                SceneManager.LoadScene(1);
            }
        });

        buttons[1].onClick.AddListener(() => {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                if (YandexGame.savesData.lvl2Unlocked)
                {
                    YandexGame.savesData.currentLevel = 1;
                    YandexGame.SaveProgress();
                    SceneManager.LoadScene(3);
                }
                else if (YandexGame.savesData.money >= 15000)
                {
                    Unlock();
                    YandexGame.savesData.lvl2Unlocked = true;
                    YandexGame.savesData.money -= 15000;
                    YandexGame.savesData.currentLevel = 1;
                    YandexGame.SaveProgress();
                    SceneManager.LoadScene(3);
                }
            }   
        });
    }
}

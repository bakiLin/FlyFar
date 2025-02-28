using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CategoryManager : MonoBehaviour
{
    [Inject]
    private SpriteManager selectManager;

    [SerializeField]
    private GameObject[] category;

    [SerializeField]
    private GameObject[] windows;

    private Button[] buttons;

    private Image[] images;

    private void Awake()
    {
        buttons = new Button[category.Length];
        images = new Image[category.Length];

        for (int i = 0; i < category.Length; i++)
        {
            images[i] = category[i].GetComponent<Image>();
            buttons[i] = category[i].GetComponent<Button>();

            SetButton(buttons[i], i);
        }
    }

    private void SetButton(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                windows[i].SetActive(i == index);

                if (i == index) images[i].sprite = selectManager.selectedBorder;
                else images[i].sprite = selectManager.commonBorder;
            }
        });
    }
}

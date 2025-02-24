using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CategoryData : MonoBehaviour
{
    [Inject]
    private ShopButtonManager shopButtonManager;

    [SerializeField]
    private GameObject options;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public Image Select()
    {
        options.SetActive(true);

        return image;
    }

    private void OnEnable()
    {
        shopButtonManager.onCategory += () => options.SetActive(false);
    }
}

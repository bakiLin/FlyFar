using UnityEngine;
using UnityEngine.UI;

public class CategoryData : MonoBehaviour
{
    [SerializeField]
    private GameObject options;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public Image TurnOn()
    {
        options?.SetActive(true);

        return image;
    }

    public void TurnOff()
    {
        options?.SetActive(false);
    }
}

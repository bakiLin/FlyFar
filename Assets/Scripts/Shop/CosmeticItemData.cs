using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class CosmeticItemData : MonoBehaviour
{
    [Inject]
    private CoinManager coinManager;

    [Inject]
    protected SpriteManager spriteManager;

    [SerializeField]
    protected int id, cost;

    protected ImageManager imageManager;

    private void Awake()
    {
        imageManager = GetComponentInParent<ImageManager>();

        if (GetType() == typeof(ColorData)) SetBorder(YandexGame.savesData.colorUnlocked);
        else if (GetType() == typeof(FaceData)) SetBorder(YandexGame.savesData.faceUnlocked);

        GetComponent<Button>().onClick.AddListener(() => Select());
    }

    private void SetBorder(List<int> list)
    {
        transform.Find("Cost").GetComponent<TextMeshProUGUI>().text = cost.ToString();

        if (list.Contains(id))
        {
            transform.Find("Block").gameObject.SetActive(false);
            transform.Find("Cost").gameObject.SetActive(false);
        }
    }

    protected virtual void Select()
    {
        coinManager.UpdateCoinText();
        transform.Find("Block").gameObject.SetActive(false);
        transform.Find("Cost").gameObject.SetActive(false);
        imageManager.SetBorders(GetComponent<Image>());
    }
}

using UnityEngine;
using YG;

public class PlayerAppearance : MonoBehaviour
{
    [SerializeField]
    private Sprite[] color, face;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = color[YandexGame.savesData.color];

        transform.Find("Face").GetComponent<SpriteRenderer>().sprite = face[YandexGame.savesData.face];
    }
}

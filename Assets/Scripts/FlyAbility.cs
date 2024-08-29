using UnityEngine;

public class FlyAbility : MonoBehaviour
{
    [SerializeField]
    private RectTransform chargeBar;

    [SerializeField]
    private GameObject chargePrefab;

    [SerializeField]
    private int skillNumber;

    private void Start() //Fills Charge Bar with X number of skill charges
    {
        float chargeHeight = chargeBar.sizeDelta.y / skillNumber;
        Vector2 size = new Vector2(chargeBar.sizeDelta.x, chargeHeight);
        Vector2 position = new Vector2(0f, (chargeBar.sizeDelta.y - chargeHeight) / 2);
        Vector2 offset = new Vector2(0, chargeHeight);

        for (int i = 0; i < skillNumber; i++)
        {
            RectTransform charge = Instantiate(chargePrefab, chargeBar.gameObject.transform).GetComponent<RectTransform>();
            charge.sizeDelta = size;
            charge.anchoredPosition = position - offset * i;
        }
    }
}

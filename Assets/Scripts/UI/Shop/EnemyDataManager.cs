using TMPro;
using UnityEngine;

public class EnemyDataManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title, description, costText;

    public void SetData(string name, string desc, string cost)
    {
        title.text = name;
        description.text = desc;
        costText.text = cost;
    }
}

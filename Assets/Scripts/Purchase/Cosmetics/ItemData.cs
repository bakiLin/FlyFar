using TMPro;
using UnityEngine;
using YG;

public class ItemData : MonoBehaviour
{
    public enum Type
    {
        Color,
        Face
    } 

    public Type type { get; protected set; }
    public int id, cost;
    public bool locked { get; protected set; }

    protected void LockStatus()
    {
        if (!locked) Unlock();
        else
        {
            GameObject obj = transform.Find("Cost").gameObject;
            obj.GetComponent<TextMeshProUGUI>().text = cost.ToString();
        }
    }

    private void Unlock()
    {
        transform.Find("Block").gameObject.SetActive(false);
        transform.Find("Cost").gameObject.SetActive(false);
    }

    public virtual void SetData() { }

    public bool Buy()
    {
        bool state = YandexGame.savesData.money > cost;

        if (state)
        {
            locked = false;

            YandexGame.savesData.money -= cost;

            SetData();
            Unlock();
        }

        return state;
    }
}

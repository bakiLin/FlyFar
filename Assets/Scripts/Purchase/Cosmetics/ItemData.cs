using TMPro;
using UnityEngine;
using YG;

public class ItemData : MonoBehaviour
{
    public int id, cost;
    public bool locked { get; protected set; }

    protected void LockStatus()
    {
        if (!locked) Unlock();
        else SetCost();
    }

    private void Unlock()
    {
        transform.Find("Block").gameObject.SetActive(false);
        transform.Find("Cost").gameObject.SetActive(false);
    }

    private void SetCost()
    {
        GameObject obj = transform.Find("Cost").gameObject;
        obj.GetComponent<TextMeshProUGUI>().text = cost.ToString();
    }

    public bool Buy()
    {
        if (YandexGame.savesData.money > cost)
        {
            locked = false;

            YandexGame.savesData.money -= cost;

            SetData();
            Unlock();

            return true;
        }

        return false;
    }

    public virtual void SetData() { }
}

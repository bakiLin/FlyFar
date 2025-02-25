using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ShopButtonManager : MonoBehaviour
{
    [Inject]
    private SelectManager selectManager;

    [Inject]
    private LevelItemDataManager levelItemManager;

    [Inject]
    private CoinManager coinManager;

    public Action onCategory;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetCategory(CategoryData data)
    {
        onCategory?.Invoke();
        selectManager.SetCategory(data.Select());
    }

    public void SetCosmetic(ItemData data)
    {
        if (data.locked)
        {
            if (data.Buy())
            {
                coinManager.UpdateCoinText();

                if (data.type.Equals(ItemData.Type.Color)) selectManager.SetColor();
                else selectManager.SetFace();
            }
        }
        else
        {
            data.SetData();

            if (data.type.Equals(ItemData.Type.Color)) selectManager.SetColor();
            else selectManager.SetFace();
        }
    }

    public void SetLevelItemData(LevelItemData data)
    {
        levelItemManager.SetData(data);

        if (data.GetType().Name == "EnemyData") selectManager.SetEnemy(data.image);
        else selectManager.SetPlayer(data.image);
    }
}

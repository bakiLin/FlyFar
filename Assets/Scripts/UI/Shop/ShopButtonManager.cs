using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ShopButtonManager : MonoBehaviour
{
    [Inject]
    private SelectManager selectManager;

    [Inject]
    private EnemyDataManager enemyDataManager;

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

    public void SetEnemyData(EnemyData data)
    {
        enemyDataManager.SetData(data.name, data.description, data.cost[0].ToString());
        selectManager.SetEnemy(data.image);
    }
}

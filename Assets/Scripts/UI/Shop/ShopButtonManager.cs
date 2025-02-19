using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ShopButtonManager : MonoBehaviour
{
    [SerializeField]
    private SelectManager selectManager;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveColor(int color)
    {
        YandexGame.savesData.color = color;
        YandexGame.SaveProgress();

        selectManager.SetColor();
    }

    public void SaveFace(int face)
    {
        YandexGame.savesData.face = face;
        YandexGame.SaveProgress();

        selectManager.SetFace();
    }
}

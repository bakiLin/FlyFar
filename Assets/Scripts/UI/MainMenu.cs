using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Clear()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();

        SceneManager.LoadScene(0);
    }
}

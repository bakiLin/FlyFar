using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ClearProgress : MonoBehaviour
{
    public void Clear()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
        SceneManager.LoadScene(0);
    }
}

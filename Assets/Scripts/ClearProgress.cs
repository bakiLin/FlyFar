using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ClearProgress : MonoBehaviour
{
    private Button button;

    private async void Awake()
    {
        button = GetComponent<Button>();

        while (!YandexGame.SDKEnabled) await UniTask.DelayFrame(10);

        button.onClick.AddListener(() =>
        {
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
            SceneManager.LoadScene(0);
        });
    }
}

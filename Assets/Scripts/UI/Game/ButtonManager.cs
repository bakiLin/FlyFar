using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using YG;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    [Inject]
    private GameOver gameOver;

    private Tween tween;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }

    public void Pause(RectTransform window)
    {
        Time.timeScale = 0f;

        tween.Kill();
        tween = window.DOAnchorPosY(-200f, 1f)
            .SetEase(Ease.OutQuart)
            .SetUpdate(true);
    }

    public void Resume(RectTransform window)
    {
        Time.timeScale = 1f;

        tween.Kill();
        tween = window.DOAnchorPosY(200f, 1f)
            .SetEase(Ease.InOutCubic)
            .SetUpdate(true);
    }

    public void RewardedAd() => YandexGame.RewVideoShow(0);

    private void GetReward(int id) => gameOver.GetReward();

    private void OnEnable() => YandexGame.RewardVideoEvent += GetReward;

    private void OnDisable() => YandexGame.RewardVideoEvent -= GetReward;
}

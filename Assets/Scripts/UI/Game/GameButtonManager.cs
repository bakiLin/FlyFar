using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameButtonManager : MonoBehaviour
{
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
}

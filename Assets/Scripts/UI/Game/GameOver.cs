using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class GameOver : MonoBehaviour
{
    [Inject]
    private TextManager textManager;

    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private RectTransform window;

    [SerializeField]
    private TextMeshProUGUI coinText;

    [SerializeField]
    private float windowPosition, time;

    private void WindowAnimation()
    {
        coinText.text = textManager.coin.ToString();

        window.DOAnchorPosY(windowPosition, time)
            .SetEase(Ease.OutQuart);
    }

    //private void OnEnable()
    //{
    //    playerSpeed.onStop += WindowAnimation;
    //}
}

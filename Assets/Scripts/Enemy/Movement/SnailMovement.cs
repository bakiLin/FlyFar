using DG.Tweening;
using UnityEngine;
using Zenject;

public class SnailMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float speed;

    private Tween tween;

    private void Awake()
    {
        playerSpeed.onStop += () => Move(25f);
    }

    private void OnEnable()
    {
        if (playerSpeed.speed.Value > 0f) Move(-25f);
        else Move(25f);
    }

    private void OnDisable()
    {
        tween.Kill();
    }

    private void Move(float direction)
    {
        tween.Kill();
        tween = transform.DOMoveX(direction, speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => { gameObject.SetActive(false); });
    }
}

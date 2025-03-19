using DG.Tweening;
using UnityEngine;
using Zenject;

public class EvenSpeedMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float speed;

    public Tween tween;

    private void Awake() => playerSpeed.onStop += Move;

    private void OnEnable() => Move();

    private void Move()
    {
        tween.Kill();

        if (playerSpeed.speed.Value > playerSpeed.stopSpeed)
        {
            tween = transform.DOMoveX(-25f, speed)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => { gameObject.SetActive(false); });
        }
        else
        {
            tween = transform.DOMoveX(25f, speed)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => { gameObject.SetActive(false); });
        }
    }
}

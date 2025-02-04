using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public class BackgroundMovement : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float multiply, movePosition;

    private Tween tween;

    private void Move()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (playerSpeed.GetSpeed() == 0f) 
            yield return null;

        ChangeSpeed();
    }

    private void ChangeSpeed()
    {
        tween.Kill();
        tween = transform.DOMoveX(movePosition, playerSpeed.GetSpeed() * multiply)
            .SetSpeedBased().SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                transform.position = new Vector3(0f, transform.position.y);
                ChangeSpeed();
            });
    }

    private void OnEnable()
    {
        inputScript.onStart += Move;
        playerSpeed.onChanged += ChangeSpeed;
    }

    private void OnDisable()
    {
        inputScript.onStart -= Move;
        playerSpeed.onChanged -= ChangeSpeed;
    }
}

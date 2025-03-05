using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using Zenject;

public class BackgroundMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float positionX, multiply;

    private CancellationTokenSource cts;

    private void Move()
    {
        if (cts != null) cts.Cancel();

        cts = new CancellationTokenSource();

        MoveAsync(cts.Token).Forget();
    }

    private async UniTaskVoid MoveAsync(CancellationToken token)
    {
        while (true)
        {
            await transform.DOMoveX(positionX, playerSpeed.speed.Value * multiply)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => { transform.position = new Vector3(0f, transform.position.y); })
                .WithCancellation(token);
        }
    }

    private void OnEnable()
    {
        playerSpeed.onChange += Move;
        playerSpeed.onStop += () => { cts?.Cancel(); };
    }

    private void OnDisable()
    {
        playerSpeed.onChange -= Move;
    }

    private void OnDestroy() => cts?.Cancel();
}

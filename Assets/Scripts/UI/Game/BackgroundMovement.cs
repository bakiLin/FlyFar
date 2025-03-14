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

    public async void MoveAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await transform.DOMoveX(positionX, playerSpeed.speed.Value * multiply)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(() => { transform.position = new Vector3(0f, transform.position.y); })
                .WithCancellation(token);
        }
    }
}

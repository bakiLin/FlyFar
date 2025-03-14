using System.Threading;
using UnityEngine;
using Zenject;

public class BackgroundManager : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    private BackgroundMovement[] background;

    private CancellationTokenSource cts;

    private void Awake()
    {
        background = new BackgroundMovement[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            background[i] = transform.GetChild(i).GetComponent<BackgroundMovement>();
        }
    }

    private void Move()
    {
        cts?.Cancel();
        cts = new CancellationTokenSource();

        foreach (var b in background) b.MoveAsync(cts.Token);
    }

    private void OnEnable()
    {
        playerSpeed.onChange += Move;
        playerSpeed.onStop += () => cts.Cancel();
    }

    private void OnDestroy() => cts?.Cancel();
}

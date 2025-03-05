using Cysharp.Threading.Tasks;
using System.Threading;
using TMPro;
using UnityEngine;
using Zenject;

public class DistanceManager : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private InputScript inputScript;

    private CancellationTokenSource cts = new CancellationTokenSource();

    private TextMeshProUGUI distanceText;

    private int distance;

    private void Awake()
    {
        distanceText = GetComponent<TextMeshProUGUI>();
    }

    private async UniTaskVoid UpdateDistanceAsync(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();

            distance += Mathf.RoundToInt(playerSpeed.speed.Value);

            distanceText.text = $"{distance.ToString()} m";

            await UniTask.Delay(1000, cancellationToken: token);
        }
    }

    private void OnEnable()
    {
        inputScript.onStart += () => { UpdateDistanceAsync(cts.Token).Forget(); };
        playerSpeed.onStop += cts.Cancel;
    }

    private void OnDestroy() => cts.Cancel();
}

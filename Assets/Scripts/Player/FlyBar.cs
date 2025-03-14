using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FlyBar : MonoBehaviour
{
    [Inject]
    private FlyPower flyPower;

    private Image fill;

    private CanvasGroup canvasGroup;

    private CancellationTokenSource cts = new CancellationTokenSource();

    private void Awake()
    {
        fill = transform.Find("Fill").GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public async UniTaskVoid Fill()
    {
        cts = new CancellationTokenSource();

        canvasGroup.alpha = 1.0f;

        while (!cts.IsCancellationRequested)
        {
            await fill.DOFillAmount(1f, 0.7f - 0.7f * fill.fillAmount)
                .SetEase(Ease.Linear)
                .OnComplete(() => { 
                    flyPower.GetFlyPower();
                    fill.fillAmount = 0f;
                })
                .WithCancellation(cts.Token);
        }
    }

    public void StopFill()
    {
        canvasGroup.alpha = 0f;
        cts.Cancel();
    }
}

using DG.Tweening;
using UnityEngine;
using Zenject;

public class Wing : MonoBehaviour
{
    [Inject]
    private FlyPower flyPower;

    [SerializeField]
    private Vector3 rotation;

    private Tween tween;

    private Quaternion quaternion;

    private void Awake()
    {
        quaternion = transform.rotation;
    }

    private void OnEnable()
    {
        tween.Kill();
        tween = transform.DORotate(rotation, flyPower.time)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() => {
                transform.rotation = quaternion;
                gameObject.SetActive(false);
            });
    }
}

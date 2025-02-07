using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public class WingBehaviour : MonoBehaviour
{
    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private float rotateDuration;

    [SerializeField]
    private bool addForce;

    private Tween tween;

    private Quaternion rotation;

    private void Awake()
    {
        rotation = transform.rotation;
    }

    public void Power(Vector3 rotationValue, float force)
    {
        StartCoroutine(FlyCoroutine(rotationValue, force));
    }

    private IEnumerator FlyCoroutine(Vector3 rotationValue, float force)
    {
        transform.rotation = rotation;

        tween.Kill();
        tween = transform.DORotate(rotationValue, rotateDuration)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() => { gameObject.SetActive(false); });

        if (addForce)
        {
            yield return new WaitForSeconds(rotateDuration / 2);
            playerGravity.AddGravity(force);
        }

        yield return null;
    }
}

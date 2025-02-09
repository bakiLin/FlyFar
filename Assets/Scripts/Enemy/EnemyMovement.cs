using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private float minSpeed, maxSpeed;

    private Tween tween;

    private Random random = new Random();

    private void OnEnable()
    {
        playerSpeed.onChanged += ChangeSpeed;

        Move(new Vector3(-20f, transform.position.y));
    }

    private void OnDisable()
    {
        playerSpeed.onChanged -= ChangeSpeed;
    }

    private void Move(Vector3 position)
    {
        double value = random.NextDouble();
        double range = (double)(maxSpeed - minSpeed);
        double speed = (value * range) + minSpeed;

        tween.Kill();

        tween = transform.DOMove(position, (float) speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => { gameObject.SetActive(false); });
    }

    private void ChangeSpeed()
    {
        if (playerSpeed.GetSpeed() < 1f) 
        {
            Move(new Vector3(20f, transform.position.y));
        }
    }
}

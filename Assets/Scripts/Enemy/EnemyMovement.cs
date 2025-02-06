using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private int minSpeed, maxSpeed;

    private Vector3 position;

    private Tween tween;

    private Random random = new Random();

    private void Move()
    {
        if (playerSpeed.GetSpeed() > 0f)
            position = new Vector3(-20f, transform.position.y);
        else
            position = new Vector3(20f, transform.position.y);

        tween.Kill();

        tween = transform.DOMove(position, random.Next(minSpeed, maxSpeed))
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => 
            { 
                gameObject.SetActive(false); 
            });
    }

    private void OnEnable()
    {
        Move();

        playerSpeed.onChanged += Move;
    }

    private void OnDisable()
    {
        playerSpeed.onChanged -= Move;
    }
}

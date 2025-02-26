using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class FlyPower : MonoBehaviour
{
    [Inject]
    private TextManager textManager;

    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private GameObject left, right;

    [HideInInspector]
    public int num;

    public float force, time;

    public async void Fly()
    {
        if (num > 0f)
        {
            num--;

            left.SetActive(true);
            right.SetActive(true);

            textManager.SetPower(num);

            await UniTask.Delay((int)(time * 400));

            playerGravity.AddGravity(force);
        }
    }
}

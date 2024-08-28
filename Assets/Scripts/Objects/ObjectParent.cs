using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObjectParent : MonoBehaviour
{
    [Inject]
    protected Config config;

    protected Random random = new();

    protected virtual float RandomValue(float[] arr)
    {
        return (float) random.NextDouble() * (arr[1] - arr[0]) + arr[0];
    }
}

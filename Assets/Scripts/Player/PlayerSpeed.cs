using System;
using UniRx;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    [SerializeField]
    private float minSpeed, midSpeed, maxSpeed;

    [HideInInspector]
    public FloatReactiveProperty speedProperty;

    private CompositeDisposable disposable = new CompositeDisposable();

    public Action onChanged;

    private void Awake()
    {
        speedProperty.Subscribe(_ =>
        {
            onChanged?.Invoke();
        }).AddTo(disposable);
    }

    public void Jump(float value)
    {
        if (value <= 0.5f) speedProperty.Value = minSpeed;
        else if (value <= 0.8f) speedProperty.Value = midSpeed;
        else speedProperty.Value = maxSpeed;
    }

    public void SetSpeed(float value) => speedProperty.Value = value;

    public float GetSpeed() => speedProperty.Value;

    private void OnDisable() 
    {
        disposable.Clear();
    }
}

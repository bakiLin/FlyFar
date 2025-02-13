using System;
using UniRx;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public Action onChange, onStop;

    private CompositeDisposable disposable = new CompositeDisposable();

    private float speed;

    public void AddSpeed(float value)
    {
        speed += value;
        speed = Mathf.RoundToInt(speed);
        
        if (speed < 7f)
        {
            speed = 0f;
            onStop?.Invoke();
        }

        onChange?.Invoke();
    }

    public float GetSpeed() => speed;

    private void OnDisable() => disposable.Clear();
}

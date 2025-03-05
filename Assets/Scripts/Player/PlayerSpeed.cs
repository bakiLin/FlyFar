using System;
using UnityEngine;
using UniRx;

public class PlayerSpeed : MonoBehaviour
{
    [HideInInspector]
    public FloatReactiveProperty speed;

    public Action onChange, onStop;

    public void AddSpeed(float value)
    {
        speed.Value += Mathf.RoundToInt(value);

        if (speed.Value > 5f) onChange?.Invoke();
        else
        {
            speed.Value = 0f;
            onStop?.Invoke();
        }
    }
}

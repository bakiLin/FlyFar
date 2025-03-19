using System;
using UnityEngine;
using UniRx;

public class PlayerSpeed : MonoBehaviour
{
    [HideInInspector]
    public FloatReactiveProperty speed;

    [HideInInspector]
    public float stopSpeed = 5f;

    public Action onChange, onStop;

    public void AddSpeed(float value)
    {
        speed.Value += Mathf.RoundToInt(value);

        if (speed.Value > stopSpeed) 
            onChange?.Invoke();
        else
        {
            speed.Value = 0f;
            onStop?.Invoke();
        }
    }
}

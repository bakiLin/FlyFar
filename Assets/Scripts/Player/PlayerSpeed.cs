using System;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public float speed { get; private set; }

    public Action onChange, onStop;

    public void AddSpeed(float value)
    {
        speed += Mathf.RoundToInt(value);

        if (speed > 5f) onChange?.Invoke();
        else
        {
            speed = 0f;
            onStop?.Invoke();
        }
    }
}

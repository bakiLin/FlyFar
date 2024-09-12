using System;
using UnityEngine;

public class SpawnerState : MonoBehaviour
{
    public Action OnChangeRunState;
    public Action OnSpeedChange;

    public void ChangeRunState() => OnChangeRunState?.Invoke();
    public void ChangeSpeed() => OnSpeedChange?.Invoke();
}

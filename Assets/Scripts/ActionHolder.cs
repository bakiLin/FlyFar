using System;
using UnityEngine;

public class ActionHolder : MonoBehaviour
{
    public Action OnChangeRunState;
    public Action OnChangeSpeed;

    public void ChangeRunState() => OnChangeRunState?.Invoke();
    public void ChangePlatformSpeed() => OnChangeSpeed?.Invoke();
}

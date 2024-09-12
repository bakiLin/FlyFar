using System;
using UnityEngine;

public class SpawnerState : MonoBehaviour
{
    public Action OnChangeRunState;

    public void ChangeRunState() => OnChangeRunState?.Invoke();
}

using System;
using UnityEngine;

public class ActionHolder : MonoBehaviour
{
    public Action OnChangeRunState;
    public Action OnHitGround;

    public void ChangeRunState() => OnChangeRunState?.Invoke();
    public void HitGround() => OnHitGround?.Invoke();
}

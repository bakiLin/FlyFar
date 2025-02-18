using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField]
    private float force;

    [SerializeField]
    private float speedLoss;

    public float Force() => force;

    public float SpeedLoss() => speedLoss;
}

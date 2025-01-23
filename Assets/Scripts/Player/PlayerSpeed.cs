using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    [SerializeField]
    private float minSpeed, midSpeed, maxSpeed;

    private float speed;

    public void Jump(float powerBarValue)
    {
        if (powerBarValue <= 0.5f) speed = minSpeed;
        else if (powerBarValue <= 0.8f) speed = midSpeed;
        else speed = maxSpeed;
    }

    public float GetSpeed() => speed;
}

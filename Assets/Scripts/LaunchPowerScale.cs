using UnityEngine;

public class LaunchPowerScale : MonoBehaviour
{
    [SerializeField]
    private Transform pointer;

    [SerializeField]
    private float[] pointerMax;

    private bool right, pointerStop;

    private void Update()
    {
        if (!pointerStop)
        {
            if (pointer.position.x <= pointerMax[0]) right = true;
            else if (pointer.position.x >= pointerMax[1]) right = false;

            float direction = right ? 1 : -1;
            pointer.transform.Translate(new Vector2(direction, 0f) * Time.deltaTime, Space.World);
        }
    }

    public float StopPointer()
    {
        pointerStop = true;

        RaycastHit2D hit = Physics2D.Raycast(pointer.position, Vector2.up, 1f);

        if (hit) return 20f;
        else return 10f; 
    }
}

using UnityEngine;

public class ObjectMovement : ObjectParent
{
    private enum ObjectType
    {
        Ground,
        Object
    }

    [SerializeField]
    private ObjectType objectType;

    [SerializeField]
    private float[] speedDifference = new float[2];

    private float addSpeed;

    private void Start()
    {
        if (objectType == ObjectType.Object)
            addSpeed = RandomValue(speedDifference);
    }

    void Update()
    {
        transform.Translate((config.platformSpeed - addSpeed) * Time.deltaTime * Vector2.left);
    }
}

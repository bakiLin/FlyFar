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
        {
            addSpeed = (float)random.NextDouble();
            addSpeed = Mathf.Clamp(addSpeed, 0.15f, 0.5f);
        }
    }

    void Update()
    {
        float speed = config.platformSpeed - config.platformSpeed * addSpeed;
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}

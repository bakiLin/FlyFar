using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private enum ObjectType
    {
        Ground,
        Object
    }

    [SerializeField]
    private ObjectType objectType;

    private float multiply, speed;

    private void Start()
    {
        if (objectType == ObjectType.Object)
        {
            //multiply = (float) random.NextDouble();
            multiply = Mathf.Clamp(multiply, 0.2f, 0.4f);
        }
    }

    //void Update()
    //{
    //    speed = config.platformSpeed - config.platformSpeed * multiply;
    //    transform.Translate(speed * Time.deltaTime * Vector2.left);
    //}
}

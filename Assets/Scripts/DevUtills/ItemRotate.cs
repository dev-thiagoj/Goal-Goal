using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    //public GameObject target;
    public float speed = 1f;
    public bool canRotateY;
    public bool canRotateZ;

    private void Update()
    {
        if (canRotateY) StartRotateY();
        if (canRotateZ) StartRotateZ();
    }

    public void StartRotateY()
    {
        transform.Rotate(100 * speed * Time.deltaTime * Vector3.up);
    }

    public void StartRotateZ()
    {
        transform.Rotate(100 * speed * Time.deltaTime * Vector3.forward);
    }

    public float SpeedDirection(float f)
    {
        speed = f;
        return speed;
    }
}

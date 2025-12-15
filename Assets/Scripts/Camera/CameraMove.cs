using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    const float CameraPositionZ = -10;

    void Update()
    {
        if(target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, CameraPositionZ);
        }
    }
}

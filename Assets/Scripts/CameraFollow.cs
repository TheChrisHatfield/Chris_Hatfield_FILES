using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; // This is controlled by the Inspector

    void Start()
    {
        // Force the correct offset every time Play is pressed
        offset = new Vector3(0, 1, -6);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
    }
}

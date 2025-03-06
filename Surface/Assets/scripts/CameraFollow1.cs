using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player or object the camera follows
    public Vector3 offset = new Vector3(5f, 2f, -10f); // Camera offset
    public float smoothSpeed = 5f; // Smoothing speed

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}

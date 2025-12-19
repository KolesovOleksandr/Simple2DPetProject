using UnityEngine;

public class DampedDeadzoneCamera2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;
    [SerializeField] private float deadzone = 0.35f;
    [SerializeField] private float snapDeadzone = 0.9f;
    [SerializeField] private float dampingTime = 0.08f;
    [SerializeField] private float maxSpeed = 0f;

    private Vector3 velocity;

    private const float Z = -10f;

    void Start()
    {
        if (!cam)
        {
            cam = GetComponent<Camera>();
        }

        if (!target)
        {
            return;
        }

        var p = target.position;
        transform.position = new Vector3(p.x, p.y, Z);
    }

    void LateUpdate()
    {
        if (!target || !cam) return;

        float dt = Time.deltaTime;
        if (dt <= 0f) return;

        Vector3 camPos = transform.position;
        Vector3 tPos = target.position;

        float halfH = cam.orthographicSize;
        float halfW = halfH * cam.aspect;

        Vector2 delta = new(tPos.x - camPos.x, tPos.y - camPos.y);

        float snapRadius = Mathf.Max(halfW, halfH) * snapDeadzone;
        if (delta.magnitude > snapRadius)
        {
            transform.position = new Vector3(tPos.x, tPos.y, Z);
            velocity = Vector3.zero;
            return;
        }

        float dzX = halfW * deadzone;
        float dzY = halfH * deadzone;

        float outX = 0f;
        if (Mathf.Abs(delta.x) > dzX) outX = delta.x - Mathf.Sign(delta.x) * dzX;

        float outY = 0f;
        if (Mathf.Abs(delta.y) > dzY) outY = delta.y - Mathf.Sign(delta.y) * dzY;

        Vector3 desired = new(camPos.x + outX, camPos.y + outY, Z);

        float smoothTime = Mathf.Max(0.0001f, dampingTime);

        if (maxSpeed > 0f)
        {
            transform.position = Vector3.SmoothDamp(camPos, desired, ref velocity, smoothTime, maxSpeed, dt);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(camPos, desired, ref velocity, smoothTime, Mathf.Infinity, dt);
        }

        var p = transform.position;
        transform.position = new Vector3(p.x, p.y, Z);
    }
}

using UnityEngine;

public class ChaserMovement : MonoBehaviour
{
    public float speed = 3f;
    Transform player;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + speed * Time.deltaTime * dir);
    }
}

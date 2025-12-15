using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Start()
    {
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        input = new Vector2(moveX, moveY).normalized;
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = Vector2.zero;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * input);
    }
}

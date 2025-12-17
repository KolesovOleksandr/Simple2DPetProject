using UnityEngine;

public class Player: MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    private Vector2 input;

    void Start()
    {
        rb.gravityScale = 0;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        input = new Vector2(moveX, moveY).normalized;
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}

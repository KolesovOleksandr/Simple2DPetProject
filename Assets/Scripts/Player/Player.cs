using UnityEngine;

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] float speed = 5f;
    [SerializeField] float magnetRadius = 1f;
    
    CircleCollider2D magnetCollider; 
    Rigidbody2D rb;
    Vector2 input;

    public float Speed => speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        magnetCollider = GetComponent<CircleCollider2D>();

        rb.gravityScale = 0;
        magnetCollider.radius = magnetRadius;
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

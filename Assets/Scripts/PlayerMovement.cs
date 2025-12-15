using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float speed = 5f;

    public void Start()
    {
    }

    public void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        Vector2 moveDirection = new Vector3 (moveX, moveY);

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}

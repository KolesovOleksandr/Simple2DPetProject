using UnityEngine;
using UnityEngine.InputSystem; // Required for New Input System

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 moveInput;

    void Update()
    {

        float moveX = 0f;
        float moveY = 0f;

        if (Keyboard.current != null)
        {
            moveX = Keyboard.current.dKey.ReadValue() - Keyboard.current.aKey.ReadValue();
            moveY = Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue();
        }

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
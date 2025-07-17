using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Rigidbody2D rb;

    private float moveInput;
    private bool isJumpPressed = false;

    // Mobile
    public bool moveLeftHeld = false;
    public bool moveRightHeld = false;

    void Update()
    {
        // PC input
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsOnGround())
            isJumpPressed = true;

        // Mobile input
        if (moveLeftHeld) moveInput = -1;
        else if (moveRightHeld) moveInput = 1;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (isJumpPressed && IsOnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumpPressed = false;
        }
    }

    bool IsOnGround()
    {
        return Mathf.Abs(rb.velocity.y) < 0.01f;
    }

    // Chamado pelos botões mobile
    public void JumpButton()
    {
        if (IsOnGround()) isJumpPressed = true;
    }

    public void MoveLeft(bool held)
    {
        moveLeftHeld = held;
    }

    public void MoveRight(bool held)
    {
        moveRightHeld = held;
    }



}

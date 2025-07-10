using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isMobile = true;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isJumping;

    private bool isPressingLeft = false;
    private bool isPressingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isMobile)
        {
            // Controle teclado PC
            horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }
        }
        else
        {
            // Controle Mobile
            if (isPressingLeft)
                horizontalInput = -1;
            else if (isPressingRight)
                horizontalInput = 1;
            else
                horizontalInput = 0;
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Pulo
        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    // Método para pular (chamar no botão pular do mobile)
    public void MobileJump()
    {
        isJumping = true;
    }

    // Detecta quando apertou algum botão (esquerda ou direita)
    public void OnPointerDown(PointerEventData eventData)
    {
        string btnName = eventData.pointerCurrentRaycast.gameObject.name;

        if (btnName == "ButtonLeft")
            isPressingLeft = true;
        else if (btnName == "ButtonRight")
            isPressingRight = true;
    }

    // Detecta quando soltou o botão
    public void OnPointerUp(PointerEventData eventData)
    {
        string btnName = eventData.pointerCurrentRaycast.gameObject.name;

        if (btnName == "ButtonLeft")
            isPressingLeft = false;
        else if (btnName == "ButtonRight")
            isPressingRight = false;
    }



}

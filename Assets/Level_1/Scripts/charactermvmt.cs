using UnityEngine;

public class charactermvmt : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    private bool isGrounded;
    private bool hasFlown;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        CheckGrounded();
        Fly();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Fly()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (isGrounded || !hasFlown)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                if (!isGrounded)
                {
                    hasFlown = true;
                }
            }
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            hasFlown = false; // Reset fly when grounded
        }
    }
}

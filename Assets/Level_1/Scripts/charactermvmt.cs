using UnityEngine;

public class charactermvmt : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    public bool isAlive = true;
    public bool canFly = false;
    public bool canJump = true;
    public bool canMove = true;

    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private Animator anim;
    private SoundController soundController;

    void Start()
    {
        anim = GetComponent<Animator>();
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
    }

    void Update()
    {
        // Kill the player if they fall out of bounds
        if (transform.position.y < -20 && isAlive)
        {
            Die();
        }

        if (!isAlive) return;

        if (canMove)
            Move();

        if (canFly)
            Fly();
        else if (canJump)
            Jump();

        UpdateAnimator();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Flip sprite based on direction
        if (moveInput < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (moveInput > 0)
            GetComponent<SpriteRenderer>().flipX = false;
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded)
        {
            Fly();
        }
    }

    void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            soundController.playJumpSound();
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void UpdateAnimator()
    {
        if (anim == null) return;

        // Animator parameters for blend tree and transitions
        anim.SetFloat("xvelocity", Mathf.Abs(rb.linearVelocity.x));        // Horizontal speed
        anim.SetFloat("yvelocity", rb.linearVelocity.y);                   // Vertical speed
        anim.SetBool("isjumping", !IsOnGround());                    // Off ground = jumping
        anim.SetBool("isdead", !isAlive);                            // If player is dead
    }

    bool IsOnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    public void Die()
    {
        isAlive = false;
        rb.linearVelocity = Vector2.zero;
        UpdateAnimator();
        Debug.Log("Player has died");
    }
}

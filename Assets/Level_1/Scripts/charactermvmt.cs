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

    private SoundController soundController;

    void Start()
    {
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
    }

    void Update()
    {
        if(transform.position.y < -15)
        {
            Die();
        }
        if (isAlive)
        {

            if (canMove) { 
                Move(); 
            }
            if (canFly)
            {
                Fly();
            }
            else if (canJump)
            {
                Jump();
            }
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        if(moveInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(moveInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Fly()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded)
        {
            soundController.playJumpSound();
            Fly();
        }
    }

    public void Die()
    {
        isAlive = false;
        rb.linearVelocity = Vector2.zero;
        Debug.Log("Player has died");
    }
}

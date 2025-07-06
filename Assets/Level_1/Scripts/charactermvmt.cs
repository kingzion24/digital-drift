using UnityEngine;
using System.Threading.Tasks;

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
    public Animator anim;
    private SoundController soundController;

    void Start()
    {
        anim = GetComponent<Animator>();
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
    }

    void Update()
    {
        
        if(isAlive){
            // Kill the player if they fall out of bounds
            if (transform.position.y < -7)
            {
                Die();
            }


            if (canMove)
                Move();

            if (canFly)
                Fly();
            else if (canJump)
                Jump();
        }
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
        
        UpdateAnimator();
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
            anim.SetTrigger("jump");  // Make sure the animator has a "die" trigger set up
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

    public async Task Die()
    {
        isAlive = false;
        soundController.playGameOverSound();
        rb.linearVelocity = Vector2.zero;
        UpdateAnimator();
        // Trigger death animation
        anim.SetTrigger("die");  // Make sure the animator has a "die" trigger set up

        while (!anim.GetCurrentAnimatorStateInfo(0).IsName("die"))
        {
            await Task.Yield(); // Wait for next frame
        }

        // Wait for the animation to finish
        float animLength = anim.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay((int)(animLength * 800));

        Debug.Log("Player has died");
    }
}

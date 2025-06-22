using UnityEngine;

public class charactermvmt : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool isAlive = true;

    void Update()
    {
        if (isAlive)
        { 
            Move();
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

    public void Die()
    {
        isAlive = false;
        rb.linearVelocity = Vector2.zero; // Stop movement
        Debug.Log("Player has died");
    }
}

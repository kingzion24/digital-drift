using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 4f;
    public Rigidbody2D rb;


    void Start()
    {
        // You can assign the Rigidbody2D via Inspector or automatically here
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Make the player jump when you press space or left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // End game on collision with pipes or ground
        Debug.Log("Player hit something!");
         
    }
}

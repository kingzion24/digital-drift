using UnityEngine;

public class enemy_mover : MonoBehaviour
{
    public float moveRate = 1f; // Initial units per second
    public float acceleration = 0.8f; // Units per second squared
    public float maxSpeed = 5f; // Maximum speed limit

    public LogicScript logic;

    private float currentMoveRate;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        currentMoveRate = moveRate;
    }

    void Update()
    {
        // Increase movement rate over time
        currentMoveRate += acceleration * Time.deltaTime;
        currentMoveRate = Mathf.Min(currentMoveRate, maxSpeed); // Clamp to max speed
        // Move the object to the right
        transform.position += new Vector3(currentMoveRate * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.gameOver(); // Trigger game over logic when hitting a wall
        }
        else if (other.CompareTag("ground"))
        {
            Destroy(other);
        }
    }
}

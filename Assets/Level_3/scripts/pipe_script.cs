using UnityEngine;

public class pipe_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5;
    public float deadZone = -13; // X position where the pipe is considered out of bounds and should be destroyed
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.addScore(1); // Add score when touching the player
        }
        
    }
}
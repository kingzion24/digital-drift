using UnityEngine;

public class enemy_mover : MonoBehaviour
{
    public float stretchRate = 1f; // Units per second

    public LogicScript logic;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x += stretchRate * Time.deltaTime;  // Increase width
        transform.localScale = scale;

        // Move the object to the right so it stretches rightwards
        transform.position += new Vector3(stretchRate * 0.5f * Time.deltaTime, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.gameOver(); // Trigger game over logic when hitting a wall
        }
    }
}

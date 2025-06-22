using UnityEngine;

public class FallingPiece : MonoBehaviour
{
    public float fallSpeed = 2f;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.addScore(1); // Add score when touching the player
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Kill_Script : MonoBehaviour
{
    public LogicScript logic;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.gameOver(); // Trigger game over logic when hitting a wall
        }
    }
}

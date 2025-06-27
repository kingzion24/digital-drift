using UnityEngine;

public class Floor : MonoBehaviour
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
            logic.platformLanding();
        }
    }
}

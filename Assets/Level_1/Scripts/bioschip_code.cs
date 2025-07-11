using UnityEngine;

public class FallingPiece : MonoBehaviour
{
    public float fallSpeed = 0.2f;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed/100000 * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.pickBIOS(); 
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Floor : MonoBehaviour
{
    public LogicScript logic;
    public float destroyDistance = 10f; // Distance from the left edge of the camera to destroy

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // Get the left edge of the main camera in world coordinates
        float cameraLeftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;

        // If the floor is destroyDistance units to the left of the camera's left edge, destroy it
        if (transform.position.x < cameraLeftEdge - destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.platformLanding();
        }
    }
}

using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float baseFallSpeed = 3f;
    public float fallSpeedIncreaseRate = 0.2f; // Speed increase per second
    public float destroyOffset = 2f;

    private Camera targetCamera;
    private float screenBottomEdge;
    private bool isInitialized = false;
    public LogicScript logic;

    private float spawnTime;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        if (targetCamera == null)
            targetCamera = Camera.main;

        spawnTime = Time.time;

        Initialize();
    }

    void Update()
    {
        if (!isInitialized)
            return;

        // Calculate current fall speed based on elapsed time
        float elapsedTime = Time.time - spawnTime;
        float currentFallSpeed = baseFallSpeed + (fallSpeedIncreaseRate * elapsedTime);

        // Move the object downward
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        // Check if object has fallen below the screen
        if (transform.position.y < screenBottomEdge - destroyOffset)
        {
            DestroyObject();
        }
    }

    void Initialize()
    {
        if (targetCamera == null)
        {
            Debug.LogWarning("No camera reference found for falling object!");
            return;
        }

        float cameraHeight = targetCamera.orthographicSize * 2f;
        Vector3 cameraPosition = targetCamera.transform.position;
        screenBottomEdge = cameraPosition.y - cameraHeight / 2f;

        isInitialized = true;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.gameOver();
        }
    }
}

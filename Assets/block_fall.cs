using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [Header("Movement Settings")]
    public float fallSpeed = 3f;
    public float destroyOffset = 2f;
    
    
    private Camera targetCamera;
    private float screenBottomEdge;
    private bool isInitialized = false;
    
    void Start()
    {
        // If no camera is set, use the main camera
        if (targetCamera == null)
            targetCamera = Camera.main;
        
        Initialize();
    }
    
    void Update()
    {
        if (!isInitialized)
            return;
        
        // Move the object downward
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        
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
        
        // Calculate the bottom edge of the camera view
        float cameraHeight = targetCamera.orthographicSize * 2f;
        Vector3 cameraPosition = targetCamera.transform.position;
        screenBottomEdge = cameraPosition.y - cameraHeight / 2f;
        
        isInitialized = true;
    }
    
    // Method to handle object destruction
    void DestroyObject()
    {
        // Add destruction effects here (particles, sound, etc.)
        Destroy(gameObject);
    }
    
    
}
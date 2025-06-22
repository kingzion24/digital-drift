using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;     // The prefab to spawn
    public float spawnInterval = 2f;      // Time between spawns
    public float spawnYOffset = 1f;       // How far above the screen the object spawns
    public float xPadding = 1f;         // Padding so objects don't spawn at the exact edge

    private float topOfScreenY;
    private float leftOfScreenX;
    private float rightOfScreenX;
    private float platformwidth;

    void Start()
    {
        // Get screen boundaries in world units
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        platformwidth = platformPrefab.transform.localScale.x / 2f;
        topOfScreenY = topLeft.y;
        leftOfScreenX = topLeft.x + xPadding + platformwidth;
        rightOfScreenX = topRight.x - xPadding - platformwidth;

        // Start spawning
        InvokeRepeating(nameof(SpawnPlatform), 1f, spawnInterval);
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(leftOfScreenX, rightOfScreenX);
        float spawnY = topOfScreenY + spawnYOffset;
        Vector3 spawnPosition = new Vector3(randomX, spawnY, -4f);

        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}

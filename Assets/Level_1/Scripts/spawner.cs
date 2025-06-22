using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;     // The prefab to spawn
    public float spawnInterval = 2f;      // Time between spawns
    public float spawnYOffset = 1f;       // How far above the screen the object spawns
    public float xPadding = 1f;         // Padding so objects don't spawn at the exact edge

    public float topOfScreenY = 7f;
    public float leftEdgeX = -7.72f;
    public float rightEdgeX = 8.2f;

    void Start()
    {
        leftEdgeX = leftEdgeX + xPadding;
        rightEdgeX = rightEdgeX - xPadding;

        // Start spawning
        InvokeRepeating(nameof(SpawnPlatform), 1f, spawnInterval);
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(leftEdgeX, rightEdgeX);
        float spawnY = topOfScreenY + spawnYOffset;
        Vector3 spawnPosition = new Vector3(randomX, spawnY, -4f);

        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}

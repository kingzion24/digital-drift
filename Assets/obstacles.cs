using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform obstacleParent; // Parent object containing obstacle prefabs
    public float spawnInterval = 2f;
    public float spawnXRange = 8f; // horizontal spawn range
    public float spawnHeight = 6f; // how high to spawn from screen top

    private GameObject[] obstaclePrefabs;

    void Start()
    {
        // Load all children (1, 2, 3, 4) from the parent into an array
        int childCount = obstacleParent.childCount;
        obstaclePrefabs = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            obstaclePrefabs[i] = obstacleParent.GetChild(i).gameObject;
        }

        // Start spawning obstacles repeatedly
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Pick random prefab
        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject prefab = obstaclePrefabs[index];

        // Random X position within screen range
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

        // Instantiate obstacle
        GameObject newObstacle = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // Optional: add Rigidbody2D on spawn if it doesn't have one yet
        if (newObstacle.GetComponent<Rigidbody2D>() == null)
        {
            newObstacle.AddComponent<Rigidbody2D>();
        }
    }
}

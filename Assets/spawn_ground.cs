using UnityEngine;

public class spawn_ground : MonoBehaviour
{
    public GameObject groundPrefab;     // The ground prefab to spawn
    public float spawnX = 0f;           // Starting X coordinate for spawning
    public float[] yPositions = new float[4]; // Array: [0] = no ground, [1] = ground, [2] = mid ground, [3] = high ground
    public int sequenceLength = 50;     // Number of ground objects to spawn

    void Start()
    {
        SpawnGroundSequence();
    }

    void SpawnGroundSequence()
    {
        if (groundPrefab == null)
        {
            Debug.LogError("groundPrefab is not assigned.");
            return;
        }

        float groundWidth = 1f;
        Renderer renderer = groundPrefab.GetComponent<Renderer>();
        if (renderer != null)
        {
            groundWidth = renderer.bounds.size.x;
        }
        else
        {
            Debug.LogWarning("groundPrefab does not have a Renderer component. Using default groundWidth = 1f.");
        }

        int[] groundPattern = new int[sequenceLength];

        // First spawn
        groundPattern[0] = Random.Range(2, 3); // 1 or 2 only

        for (int i = 1; i < sequenceLength; i++)
        {
            int prevIndex = groundPattern[i - 1];
            int nextIndex;

            // Can only go up by 1, or down by any amount
            int max = Mathf.Min(prevIndex + 2, yPositions.Length);
            int min = prevIndex==0?1 : 0; // If prevIndex is 0, we can only go to 1, otherwise we can go down to 0

            // Randomly pick from possible indices
            nextIndex = Random.Range(min, max);
            groundPattern[i] = nextIndex;
        }

        float currentX = spawnX;

        for (int i = 0; i < groundPattern.Length; i++)
        {
            int index = groundPattern[i];
            if (index >= 0 && index < yPositions.Length)
            {
                float y = yPositions[index];

                if (y!=0) // Treat 0 as "no ground"
                {
                    Vector3 spawnPos = new Vector3(currentX, y, -5f);
                    Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                }
            }
            currentX += groundWidth;
        }
    }
}

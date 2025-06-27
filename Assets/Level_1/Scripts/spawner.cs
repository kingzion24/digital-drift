using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float startInterval = 2f;           // Initial spawn interval
    public float endInterval = 0.5f;           // Final spawn interval
    public float intervalDecreaseDuration = 30f; // Time over which interval decreases (seconds)
    public float spawnYOffset = 1f;
    public float xPadding = 1f;

    public float topOfScreenY = 7f;
    public float leftEdgeX = -7.72f;
    public float rightEdgeX = 8.2f;

    private float elapsedTime = 0f;

    void Start()
    {
        leftEdgeX = leftEdgeX + xPadding;
        rightEdgeX = rightEdgeX - xPadding;

        StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms()
    {
        while (true)
        {
            SpawnPlatform();

            // Calculate current interval
            float t = Mathf.Clamp01(elapsedTime / intervalDecreaseDuration);
            float currentInterval = Mathf.Lerp(startInterval, endInterval, t);

            yield return new WaitForSeconds(currentInterval);

            elapsedTime += currentInterval;
        }
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(leftEdgeX, rightEdgeX);
        float spawnY = topOfScreenY + spawnYOffset;
        Vector3 spawnPosition = new Vector3(randomX, spawnY, -4f);

        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}

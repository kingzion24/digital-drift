using UnityEngine;
using System.Collections;


public class pipespawner : MonoBehaviour
{
    public GameObject pipe;
    
    public float startInterval = 2f;           // Initial spawn interval
    public float endInterval = 0.5f;           // Final spawn interval
    public float intervalDecreaseDuration = 30f; // Time over which interval decreases (seconds)
    private float elapsedTime = 0f;

    public float heightOffset = 3; // Height offset for the pipe spawn position
    void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    IEnumerator SpawnPipes()
    {
        while (true)
        {
            spawnPipe();

            // Calculate current interval
            float t = Mathf.Clamp01(elapsedTime / intervalDecreaseDuration);
            float currentInterval = Mathf.Lerp(startInterval, endInterval, t);

            yield return new WaitForSeconds(currentInterval);

            elapsedTime += currentInterval;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),transform.rotation);
    }
}

using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject piecePrefab;
    public float spawnInterval = 1.5f;
    public int maxPieces = 4;

    private int spawnedCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPiece), 1f, spawnInterval);
    }

    void SpawnPiece()
    {
        if (spawnedCount >= maxPieces)
        {
            CancelInvoke(nameof(SpawnPiece));
            return;
        }

        float screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float spawnX = Random.Range(screenLeft + 0.5f, screenRight - 0.5f);

        Vector3 spawnPosition = new Vector3(spawnX, Camera.main.orthographicSize + 1, 0f);
        Instantiate(piecePrefab, spawnPosition, Quaternion.identity);
        spawnedCount++;
    }
}

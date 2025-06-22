using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int piecesCaught = 0;
    public int totalPieces = 4;

    void Awake()
    {
        instance = this;
    }

    public void CapturePiece(GameObject piece)
    {
        piecesCaught++;
        Destroy(piece);

        if (piecesCaught >= totalPieces)
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        Debug.Log("Level Complete!");
        // Load next level or show win screen here
    }
}

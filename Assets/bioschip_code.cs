using UnityEngine;

public class FallingPiece : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CapturePiece(this.gameObject);
            Destroy(this.gameObject); // Or play a fail effect

        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject); // Or play a fail effect
        }
    }
}

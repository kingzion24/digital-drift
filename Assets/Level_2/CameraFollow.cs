using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;     // Assign the player in the Inspector
    public float smoothing = 5f; // Optional smoothing

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 currentPosition = transform.position;
            float targetX = player.position.x;

            // Smoothly interpolate to the target X position
            float newX = Mathf.Lerp(currentPosition.x, targetX, smoothing * Time.deltaTime);

            transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);
        }
    }
}

using UnityEngine;

public class pipe_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
       public float moveSpeed = 5;
       public float deadZone = -13; // X position where the pipe is considered out of bounds and should be destroyed
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }
    }
}
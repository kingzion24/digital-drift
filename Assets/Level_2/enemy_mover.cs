using UnityEngine;

public class enemy_mover : MonoBehaviour
{
    public float stretchRate = 1f; // Units per second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x += stretchRate * Time.deltaTime;  // Increase width
        transform.localScale = scale;

        // Move the object to the right so it stretches rightwards
        transform.position += new Vector3(stretchRate * 0.5f * Time.deltaTime, 0f, 0f);
    }
}

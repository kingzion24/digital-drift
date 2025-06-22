using UnityEngine;

public class WiggleEffect2D : MonoBehaviour
{
    public float wiggleAmount = 0.1f; // Distance to wiggle
    public float wiggleSpeed = 10f;   // How fast it wiggles

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float wiggleX = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount;
        float wiggleY = Mathf.Cos(Time.time * wiggleSpeed) * wiggleAmount;

        transform.position = originalPosition + new Vector3(wiggleX, wiggleY, 0f);
    }
}

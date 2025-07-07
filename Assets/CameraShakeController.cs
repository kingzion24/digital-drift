using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    [Header("Shake Timing Settings")]
    public float baseShakeInterval = 2f;
    public float minShakeInterval = 0.1f;
    public float shakeGrowthRate = 0.5f; // How fast it gets more frequent
    private float currentShakeInterval;
    private float nextShakeTime;

    [Header("Shake Intensity Settings")]
    public float baseShakeMagnitude = 0.1f;
    public float maxShakeMagnitude = 0.5f;
    public float magnitudeIncreaseRate = 0.3f; // Speed of intensity growth
    private float currentShakeMagnitude;

    [Header("Shake Duration Settings")]
    public float baseDuration = 0.15f;
    public float maxDuration = 0.4f;

    [Header("Strong Jolt Settings")]
    [Range(0f, 1f)]
    public float strongJoltProbability = 0.2f;
    public float strongJoltMultiplier = 2f; // Applied to magnitude and duration

    private Camera cam;
    private Vector3 followOffset = Vector3.zero;
    private bool isShaking = false;
    private float timeElapsed;

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main Camera not found.");
            enabled = false;
            return;
        }

        currentShakeInterval = baseShakeInterval;
        currentShakeMagnitude = baseShakeMagnitude;
        nextShakeTime = Time.time + currentShakeInterval;
        timeElapsed = 0f;
    }

    void LateUpdate()
    {
        timeElapsed += Time.deltaTime;

        // Shake frequency increases over time but approaches a limit
        float t = 1f - Mathf.Exp(-shakeGrowthRate * timeElapsed); // asymptotic growth
        currentShakeInterval = Mathf.Lerp(baseShakeInterval, minShakeInterval, t);
        currentShakeMagnitude = Mathf.Lerp(baseShakeMagnitude, maxShakeMagnitude, t);

        if (Time.time >= nextShakeTime && !isShaking)
        {
            bool isStrongJolt = Random.value < strongJoltProbability;
            float magnitude = isStrongJolt ? currentShakeMagnitude * strongJoltMultiplier : currentShakeMagnitude;
            float duration = isStrongJolt ? baseDuration * strongJoltMultiplier : baseDuration;

            StartCoroutine(Shake(magnitude, duration));
            nextShakeTime = Time.time + currentShakeInterval;
        }

        // Apply shake offset if any
        cam.transform.localPosition += followOffset;
    }

    private System.Collections.IEnumerator Shake(float magnitude, float duration)
    {
        isShaking = true;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (Time.timeScale == 0)
            {
                // If time is paused, exit shaking
                isShaking = false;
                yield break;
            }
            //float x = Random.Range(-magnitude, magnitude);
            //float y = Random.Range(-magnitude, magnitude);
            float zRot = Random.Range(-magnitude * 100f, magnitude * 100f);
            

            //followOffset = new Vector3(x, 0f, 0f);
            cam.transform.localRotation = Quaternion.Euler(0f, 0f, zRot);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cam.transform.localRotation = Quaternion.identity;

        isShaking = false;
    }

    /// <summary>
    /// Call this from outside when the player collects a BIOS chip.
    /// Reduces the shaking magnitude and resets time slightly to slow escalation.
    /// </summary>
    public void ReduceShakeFromChipCollect()
    {
        // Reduce magnitude slightly
        currentShakeMagnitude = Mathf.Max(baseShakeMagnitude, currentShakeMagnitude * 0.8f);

        // Reduce progression time to slow the rate of escalation
        timeElapsed *= 0.9f;

        // Optionally: Add a burst of calm by resetting the timer (comment out if not wanted)
        // nextShakeTime = Time.time + currentShakeInterval;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CameraGlitchController : MonoBehaviour
{
    [Header("Timing Settings")]
    public float startGlitchInterval = 2f;
    public float minGlitchInterval = 0.1f;
    public float intervalDecreaseRate = 0.05f;

    [Header("Glitch Strength Settings")]
    public float minGlitchMagnitude = 0.05f;
    public float maxGlitchMagnitude = 0.3f;

    public float minGlitchDuration = 0.05f;
    public float maxGlitchDuration = 0.4f;

    [Header("Flicker Settings")]
    public Color[] glitchColors;
    public float maxFlickerOpacity = 0.25f;

    private float currentGlitchInterval;
    private float nextGlitchTime = 0f;
    private Camera cam;
    private Transform camTransform;

    private Image glitchOverlay;
    private Material overlayMaterial;
    private bool glitching = false;

    private Vector3 followOffset = Vector3.zero; // Used to store current glitch offset

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main Camera not found.");
            enabled = false;
            return;
        }

        camTransform = cam.transform;
        currentGlitchInterval = startGlitchInterval;
        nextGlitchTime = Time.time + currentGlitchInterval;

        SetupGlitchOverlay();
    }

    void LateUpdate()
    {
        currentGlitchInterval = Mathf.Max(minGlitchInterval, currentGlitchInterval - intervalDecreaseRate * Time.deltaTime);

        if (Time.time >= nextGlitchTime && !glitching)
        {
            StartCoroutine(Glitch());
            nextGlitchTime = Time.time + currentGlitchInterval;
        }

        // Apply the current glitch offset (if any)
        camTransform.localPosition += followOffset;
    }

    System.Collections.IEnumerator Glitch()
    {
        glitching = true;

        float intensityFactor = 1f - (currentGlitchInterval / startGlitchInterval);
        float glitchMagnitude = Mathf.Lerp(minGlitchMagnitude, maxGlitchMagnitude, intensityFactor);
        float glitchDuration = Mathf.Lerp(minGlitchDuration, maxGlitchDuration, intensityFactor);

        float elapsed = 0f;

        // Set overlay flicker
        Color chosenColor = glitchColors[Random.Range(0, glitchColors.Length)];
        chosenColor.a = Random.Range(0.05f, maxFlickerOpacity);
        glitchOverlay.color = chosenColor;

        while (elapsed < glitchDuration)
        {
            if (Time.timeScale == 0)
            {
                // If time is paused, exit shaking
                glitching = false;
                yield break;
            }
            float x = Random.Range(-glitchMagnitude, glitchMagnitude);
            //float y = Random.Range(-glitchMagnitude, glitchMagnitude);
            float zRot = Random.Range(-glitchMagnitude * 100f, glitchMagnitude * 100f);

            // Apply temporary offsets
            followOffset = new Vector3(x, 0f, 0f);
            camTransform.localRotation = Quaternion.Euler(0f, 0f, zRot);

            elapsed += Time.deltaTime;
            yield return null;
        }

        followOffset = Vector3.zero;
        camTransform.localRotation = Quaternion.identity;
        glitchOverlay.color = Color.clear;

        glitching = false;
    }

    void SetupGlitchOverlay()
    {
        GameObject overlayCanvas = new GameObject("GlitchCanvas");
        overlayCanvas.transform.SetParent(cam.transform);
        overlayCanvas.transform.localPosition = Vector3.zero;

        Canvas canvas = overlayCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        GameObject imageObj = new GameObject("GlitchOverlay");
        imageObj.transform.SetParent(overlayCanvas.transform);
        glitchOverlay = imageObj.AddComponent<Image>();

        overlayMaterial = new Material(Shader.Find("UI/Default"));
        glitchOverlay.material = overlayMaterial;
        glitchOverlay.color = Color.clear;

        RectTransform rt = glitchOverlay.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }
}

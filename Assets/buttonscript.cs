using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverGrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 normalScale = Vector3.one;
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1f);
    public float growSpeed = 10f;

    public Text buttonText; // Reference to the UI Text component
    public Color normalTextColor = Color.blue;
    public Color hoverTextColor = Color.green;

    private bool isHovered = false;

    void Start()
    {
        if (buttonText != null)
        {
            buttonText.color = normalTextColor;
        }
    }

    void Update()
    {
        // Smooth scale animation
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            isHovered ? hoverScale : normalScale,
            Time.deltaTime * growSpeed
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        if (buttonText != null)
        {
            buttonText.color = hoverTextColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        if (buttonText != null)
        {
            buttonText.color = normalTextColor;
        }
    }
}

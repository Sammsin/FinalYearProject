using UnityEngine;
using TMPro; // For Text UI

public class AngleLineDrawer : MonoBehaviour
{
    public Transform lowerBack;  
    public Transform head;       
    public TextMeshProUGUI angleText;  // Assign in Inspector

    private LineRenderer lineRenderer;

    void Start()
    {
        // Initialize LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (lowerBack != null && head != null)
        {
            // Update LineRenderer positions
            lineRenderer.SetPosition(0, lowerBack.position);
            lineRenderer.SetPosition(1, head.position);

            // Calculate angle
            Vector3 direction = head.position - lowerBack.position;
            float angle = Vector3.Angle(Vector3.up, direction);

            // Change color based on angle
            Color lineColor = GetColorFromAngle(angle);
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;

            // Update UI text
            if (angleText != null)
            {
                angleText.text = "Angle: " + angle.ToString("F2") + "°";
                angleText.color = lineColor; // Optional: Change text color to match
            }
        }
    }

    Color GetColorFromAngle(float angle)
    {
        if (angle < 5f) return Color.blue;   // Good posture
        if (angle < 20f) return Color.green; // Slight tilt
        if (angle < 60f) return Color.yellow; // large tilt
        return Color.red;                      // Extreme tilt
    }

    void OnDrawGizmos()
    {
        if (lowerBack != null && head != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(lowerBack.position, head.position);
        }
    }
}

using UnityEngine;
using TMPro; // For Text UI

public class AngleLineDrawer : MonoBehaviour
{
    public Transform lowerBack;
    public Transform upperBack;
    public Transform head;
    public TextMeshProUGUI angleText;  // Assign in Inspector

    private LineRenderer lineRenderer;
    private bool useUpperBack = false; // Toggle state

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

        // Select the reference joint
        Transform referenceBack = useUpperBack ? upperBack : lowerBack;

        if (referenceBack != null && head != null)
        {
            // Update LineRenderer positions
            lineRenderer.SetPosition(0, referenceBack.position);
            lineRenderer.SetPosition(1, head.position);

            // Calculate angle
            Vector3 direction = head.position - referenceBack.position;
            float angle = Vector3.Angle(Vector3.up, direction);

            // Determine if the angle is positive or negative
            float sign = Mathf.Sign(Vector3.Cross(Vector3.up, direction).z);  // Check direction of cross product

           // if (sign < 0) angle = -angle;  // If negative, adjust angle direction

            // Change color based on angle
            Color lineColor = useUpperBack ? GetColorForUpperBack(angle) : GetColorForLowerBack(angle);
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;

            // Update UI text
            if (angleText != null)
            {
                string jointName = useUpperBack ? "Upper Back" : "Lower Back";
                angleText.text = $"{jointName} Angle: {angle:F2}°";
                angleText.color = lineColor;
            }
        }
    }

    Color GetColorForLowerBack(float angle)
    {
        if (angle < 5f) return Color.blue;    // Perfect posture
        if (angle < 20f) return Color.green;  // Slight tilt
        if (angle < 60f) return Color.yellow; // Large tilt
        return Color.red;                     // Extreme tilt
    }

    Color GetColorForUpperBack(float angle)
    {
        if (angle < 10f) return Color.blue;    // Perfect posture
        if (angle < 20f) return Color.green;  // Slight tilt
        if (angle > 20f) return Color.red; // Large tilt
        return Color.red;                     // Extreme tilt
    }
    void OnDrawGizmos()
    {
        Transform referenceBack = useUpperBack ? upperBack : lowerBack;
        if (referenceBack != null && head != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(referenceBack.position, head.position);
        }
    }

    // UI Button function to enable Upper Back
    public void EnableUpperBack()
    {
        useUpperBack = true;
    }

    // UI Button function to switch back to Lower Back
    public void DisableUpperBack()
    {
        useUpperBack = false;
    }
}

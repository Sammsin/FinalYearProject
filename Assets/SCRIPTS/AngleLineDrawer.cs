using UnityEngine;

public class AngleLineDrawer : MonoBehaviour
{
    public Transform lowerBack;  // Assign in Inspector
    public Transform head;       // Assign in Inspector
    private LineRenderer lineRenderer;

    void Start()
    {
        // Add a LineRenderer component dynamically
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (lowerBack != null && head != null)
        {
            // Update LineRenderer in Game View
            lineRenderer.SetPosition(0, lowerBack.position);
            lineRenderer.SetPosition(1, head.position);

            // Calculate and log the angle
            Vector3 direction = head.position - lowerBack.position;
            float angle = Vector3.Angle(Vector3.up, direction);
            Debug.Log("Angle: " + angle);
        }
    }

    void OnDrawGizmos()
    {
        if (lowerBack != null && head != null)
        {
            // Draw line in Scene View
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(lowerBack.position, head.position);
        }
    }
}

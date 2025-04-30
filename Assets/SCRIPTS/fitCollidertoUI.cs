using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider))]
public class FitColliderToUI : MonoBehaviour
{
    void Start()
    {
        ResizeCollider();
    }

    public void ResizeCollider()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        BoxCollider collider = GetComponent<BoxCollider>();

        Vector2 size = rectTransform.rect.size;
        Vector3 scale = rectTransform.lossyScale;

        collider.size = new Vector3(size.x * scale.x, size.y * scale.y, 0.01f);
        collider.center = new Vector3(0, 0, 0);
    }
}

using UnityEngine;
using UnityEngine.XR;

public class AttachToPalm : MonoBehaviour
{
    public XRNode handNode = XRNode.RightHand;
    public Vector3 positionOffset = new Vector3(0, 0, 0.1f);
    public Vector3 rotationOffset = Vector3.zero;

    private InputDevice device;
    private bool deviceInitialized = false;

    void Update()
    {
        if (!deviceInitialized || !device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(handNode);
            deviceInitialized = device.isValid;
        }

        if (deviceInitialized)
        {
            if (device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position) &&
                device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
            {
                // Apply rotation offset
                Quaternion adjustedRotation = rotation * Quaternion.Euler(rotationOffset);
                transform.position = position + adjustedRotation * positionOffset;
                transform.rotation = adjustedRotation;
            }
        }
    }
}

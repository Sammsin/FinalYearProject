using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Hands; // Requires Unity's XR Hands package

public class AttachToPalm : MonoBehaviour
{
    public XRNode handNode = XRNode.RightHand;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(handNode);

        if (device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos) &&
            device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot))
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }
}


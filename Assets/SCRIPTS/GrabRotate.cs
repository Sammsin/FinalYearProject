using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabRotate : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Vector3 lastPosition;
    private bool isGrabbed = false;

    void Start()
    {
        // Get the XR Grab Interactable component
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Register for the new events using the updated signature
        grabInteractable.selectEntered.AddListener(OnGrabStarted);
        grabInteractable.selectExited.AddListener(OnGrabEnded);
    }

    void Update()
    {
        // Only rotate if the object is grabbed
        if (isGrabbed)
        {
            // Calculate the movement direction of the controller (hand)
            Vector3 currentPosition = grabInteractable.interactorsSelecting[0].transform.position;
            Vector3 deltaPosition = currentPosition - lastPosition;

            // Apply rotation on the Y-axis based on horizontal movement
            transform.Rotate(Vector3.up, deltaPosition.x * 500f);  // Adjust multiplier for rotation speed

            lastPosition = currentPosition;  // Update the last position for the next frame
        }
    }

    private void OnGrabStarted(SelectEnterEventArgs args)
    {
        // Mark the object as grabbed and store its current position
        isGrabbed = true;

        // Save the initial position of the interactor (the hand/controller)
        lastPosition = args.interactorObject.transform.position;
    }

    private void OnGrabEnded(SelectExitEventArgs args)
    {
        // Mark the object as not grabbed
        isGrabbed = false;
    }
}

using UnityEngine;

public class ToggleSittingButtons : MonoBehaviour
{
    public GameObject Buttons; // Assign the GameObject in the Inspector

    public void ToggleVisibility()
    {
        Buttons.SetActive(!Buttons.activeSelf);
    }
}

using UnityEngine;

public class ToggleMultipleSittingButtons : MonoBehaviour
{
    public GameObject sitting; // Group for Button 1
    public GameObject standing; // Group for Button 2
    public GameObject neck; // Group for Button 3

    public void ShowOnlyOne(int index)
    {
        sitting.SetActive(index == 1);
        standing.SetActive(index == 2);
        neck.SetActive(index == 3);
    }
}

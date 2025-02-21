using UnityEngine;
using UnityEngine.UI;

public class PlayAnimation : MonoBehaviour
{
    public Animator animator; // Reference to Animator

    void Start()
    {
        // Get Button Component and Add Listener
        GetComponent<Button>().onClick.AddListener(PlayAnim);
    }

    void PlayAnim()
    {
        animator.Play("clip"); // Play animation by name
    }
}

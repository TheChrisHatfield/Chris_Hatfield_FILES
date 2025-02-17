using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator; // Drag the DOOR GameObject here in the Inspector
    private bool isDoorOpen = false;

    void Start()
    {
        if (doorAnimator == null)
        {
            Debug.LogError("🚨 Door Animator is missing! Assign the DOOR object in Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen)
        {
            Debug.Log("🚪 Door Triggered - Opening!");
            doorAnimator.SetTrigger("Open");
            isDoorOpen = true;
        }
    }
}

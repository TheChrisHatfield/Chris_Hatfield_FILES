using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isDoorOpen = false; // Ensures it plays only once

    void Start()
    {
        if (doorAnimator == null)
        {
            doorAnimator = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen) // Ensures it only triggers once
        {
            doorAnimator.SetTrigger("Open");
            isDoorOpen = true; // Prevents multiple triggers
        }
    }
}

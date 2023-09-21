using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string playerTag = "Player"; // Set this tag in the Inspector.
    public string animatedObjectTag = "AnimatedObject"; // Set this tag in the Inspector.
    public string triggerTag = "InteractionTrigger"; // Set this tag in the Inspector.

    private Animator animatedObjectAnimator;
    private bool isInRange = false;

    private void Start()
    {
        // Find the animated object by its tag.
        GameObject animatedObject = GameObject.FindGameObjectWithTag(animatedObjectTag);

        // Ensure the animated object exists and has an Animator component.
        if (animatedObject != null)
        {
            animatedObjectAnimator = animatedObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("No GameObject with the specified 'animatedObjectTag' found.");
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && animatedObjectAnimator != null)
        {
            // Check if the player is in range.
            if (gameObject.CompareTag(playerTag))
            {
                // Trigger the animation on the animated object.
                animatedObjectAnimator.SetTrigger("Interact");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            isInRange = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePickUp : MonoBehaviour
{
    // Reference to the player's grapple object
    public GameObject grappleObject;

    // This method is called when a collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Set the grapple activation flag to true
            ActivateGrapple();

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }

    // Custom method to activate the grapple (you can implement your own logic)
    private void ActivateGrapple()
    {
        Grapple grappleController = grappleObject.GetComponent<Grapple>();

        if (grappleController != null)
        {
            // Set the grapple activation flag to true
            //grappleController.SetGrappleActivated(true);
            Debug.Log("Grapple activated!");
        }
    }
}
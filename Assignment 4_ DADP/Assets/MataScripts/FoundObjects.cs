using UnityEngine;
using UnityEngine.UI;

public class FoundObjects : MonoBehaviour
{
    public Text FeedbackText;
    public Text CollectedPartsText; // Text to display "Plane Parts Collected: X/10"

    private int collectedPartsCount = 0; // Track the number of collected plane parts
    private bool[] planePartsFound; // An array to track which plane parts are found

    void Start()
    {
        // Initialize the array with 10 elements, all set to false (not found)
        planePartsFound = new bool[10];
        for (int i = 0; i < planePartsFound.Length; i++)
        {
            planePartsFound[i] = false;
        }

        UpdateCollectedPartsText(); // Initialize the CollectedPartsText
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        // Check if the collided object has a tag corresponding to a plane part
        for (int i = 0; i < planePartsFound.Length; i++)
        {
            string tagToCompare = "PlanePart" + (i + 1);

            if (other.CompareTag(tagToCompare) && !planePartsFound[i])
            {
                UpdateFeedback("Plane Part " + (i + 1));
                planePartsFound[i] = true;
                collectedPartsCount++;
                UpdateCollectedPartsText(); // Update the collected parts count text
                Destroy(other.gameObject); // Destroy the collided object
            }
        }
    }

    void UpdateFeedback(string newFeedback)
    {
        string currentFeedback = "<color=#HEXCOLOR>You found:</color> <color=red>" + newFeedback + "</color>";
        FeedbackText.text = currentFeedback;
    }

    void UpdateCollectedPartsText()
    {
        CollectedPartsText.text = "PLANE PARTS COLLECTED: " + collectedPartsCount + "/10";
    }
}

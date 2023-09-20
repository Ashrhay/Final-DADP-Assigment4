using UnityEngine;
using UnityEngine.UI;

public class FoundObjects : MonoBehaviour
{
    public Text FeedbackText;

    private string currentFeedback = "No Plane Parts Were Found Yet";

    private bool planePart1Found = false;
    private bool planePart2Found = false;
    private bool planePart3Found = false;
    private bool planePart4Found = false;
    private bool planePart5Found = false;

    public GameObject PlanePart1;
    public GameObject PlanePart2;
    public GameObject PlanePart3;
    public GameObject PlanePart4;
    public GameObject PlanePart5;

    void Start()
    {
        Debug.Log("Player character found: " + gameObject.name);
        Collider collider = GetComponent<Collider>();
        Debug.Log("Collider tag: " + collider.tag);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("PlanePart1") && !planePart1Found)
        {
            UpdateFeedback("Plane Part 1");
            Destroy(PlanePart1);
            planePart1Found = true;
        }
        else if (other.CompareTag("PlanePart2") && !planePart2Found)
        {
            UpdateFeedback("Plane Part 2");
            Destroy(PlanePart2);
            planePart2Found = true;
        }
        else if (other.CompareTag("PlanePart3") && !planePart3Found)
        {
            UpdateFeedback("Plane Part 3");
            Destroy(PlanePart3);
            planePart3Found = true;
        }
        else if (other.CompareTag("PlanePart4") && !planePart4Found)
        {
            UpdateFeedback("Plane Part 4");
            Destroy(PlanePart4);
            planePart4Found = true;
        }
        else if (other.CompareTag("PlayerPart5") && !planePart5Found)
        {
            UpdateFeedback("Plane Part 5");
            Destroy(PlanePart5);
            planePart5Found = true;
        }


    }

    void UpdateFeedback(string newFeedback)
    {
        currentFeedback = newFeedback;
        FeedbackText.text = "<color=#HEXCOLOR>You found:</color> <color=red>" + currentFeedback + "</color>";

    }
}

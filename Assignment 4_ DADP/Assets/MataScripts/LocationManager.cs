using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    public Text locationText;

    private string currentLocation = "Outside";

    void Start()
    {
        Debug.Log("Player character attached: " + gameObject.name);
        Collider collider = GetComponent<Collider>();
        Debug.Log("Collider tag: " + collider.tag);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Mountain"))
        {
            UpdateLocation("MOUNTAIN");
        }
        /*else if (other.CompareTag("Castle"))
        {
            UpdateLocation("CASTLE");
        } */
        else if (other.CompareTag("Jungle"))
        {
            UpdateLocation("JUNGLE");
        }
        else if (other.CompareTag("Beach"))
        {
            UpdateLocation("BEACH");
        }
        else if (other.CompareTag("Helicopter Pad"))
        {
            UpdateLocation("HELICOPTER PAD");
        }
    }

    void UpdateLocation(string newLocation)
    {
        currentLocation = newLocation;
        locationText.text = "<color=#HEXCOLOR>LOCATION:</color> <color=red>" + currentLocation + "</color>";
    }
}

using UnityEngine;
using UnityEngine.UI; // Use this if you're using UI Text
// using TMPro; // Uncomment if you're using TextMesh Pro

public class SocketInteraction : MonoBehaviour
{
    public GameObject requiredObject; // The object required to place in the socket
    public Text socketText; // Assign your Text UI element here
    // public TMP_Text socketText; // Uncomment if using TextMesh Pro
    private bool isObjectInSocket = false;

    void Start()
    {
        // Initially hide the text
        socketText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == requiredObject && !isObjectInSocket)
        {
            isObjectInSocket = true;
            DisplayText("Object placed successfully!");
            // Optionally, you can destroy or deactivate the object here
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == requiredObject)
        {
            isObjectInSocket = false;
            DisplayText(""); // Hide text if the object leaves
        }
    }

    private void DisplayText(string message)
    {
        socketText.text = message;
        socketText.gameObject.SetActive(!string.IsNullOrEmpty(message));
    }
}

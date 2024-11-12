using UnityEngine;
using UnityEngine.UI;  // Required for UI elements

public class CounterandTimer : MonoBehaviour
{
    public Text counterText;  // Reference to the UI Text element
    private int counter = 0;  // Variable to store the count

    void Start()
    {
        // Initialize the counter text
        counterText.text = "Count: " + counter;
    }

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Increment the counter
            counter++;
            // Update the counter text on screen
            counterText.text = "Count: " + counter;
        }
    }
}

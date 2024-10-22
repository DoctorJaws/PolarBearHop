using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRise : MonoBehaviour
{
    public bool rockEventTriggered;
    void Update()
    {
        // Increase the Y scale by 1 every frame
        Vector3 currentScale = transform.localScale;
        currentScale.y += 2 * Time.deltaTime; // Adjust to frame rate
        if (rockEventTriggered)
        {
            currentScale.y += 5; // Add 5 to the Y scale
            rockEventTriggered = false; // Reset the event trigger
        }

        transform.localScale = currentScale;
    }

    // Call this method to trigger the "rock" event
    public void TriggerRockEvent()
    {
        rockEventTriggered = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player capsule
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the current scene
            SceneManager.LoadScene("Main Menu");
        }
    }
}

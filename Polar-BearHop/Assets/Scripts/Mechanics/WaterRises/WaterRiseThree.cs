using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRiseThree : MonoBehaviour
{
    public bool rockEventTriggered;
    public float riseRate = 2f; // Initial rise rate

    void Update()
    {
        // Increase the Y scale by the current rise rate every frame
        Vector3 currentScale = transform.localScale;
        currentScale.y += riseRate * Time.deltaTime; // Adjust to frame rate

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
            SceneManager.LoadScene("LevelThree");
        }
        // Check if the colliding object is tagged as "Floor"
        else if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(collision.gameObject); // Destroy the "Floor" object
            riseRate += 1f; // Increase the rate of rising
        }
    }
}

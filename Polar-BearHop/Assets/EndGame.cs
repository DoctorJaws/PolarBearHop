using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

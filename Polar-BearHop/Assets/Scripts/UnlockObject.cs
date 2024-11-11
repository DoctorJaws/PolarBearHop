using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObject : MonoBehaviour
{
    // Number that corresponds to fact slot
    public int objectNumber;

    public static int collectedInPlaythrough = 0; 

    void Start()
    {
        // Checks if the collectible has been collected
        if (PlayerPrefs.GetInt("Collectible_" + objectNumber, 0) == 1)
        {
            Destroy(gameObject); 
        }
    }
    // [System.Obsolete]
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Saves the unlocked status
            PlayerPrefs.SetInt("UnlockSlot" + objectNumber, 1); 
            PlayerPrefs.SetInt("Collectible_" + objectNumber, 1);

            collectedInPlaythrough++; 
            PlayerPrefs.SetInt("CollectedInPlaythrough", collectedInPlaythrough); 

            PlayerPrefs.Save();
            Destroy(gameObject); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObject : MonoBehaviour
{
    // Number that corresponds to fact slot
    public int objectNumber; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Saves the unlocked status
            PlayerPrefs.SetInt("UnlockSlot" + objectNumber, 1); 
            PlayerPrefs.Save();
            Destroy(gameObject); 
        }
    }
}

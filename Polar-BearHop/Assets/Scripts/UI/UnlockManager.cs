using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockManager : MonoBehaviour
{
    // Array of buttons representing the locked/unlocked slots
    public Button[] unlockSlots;
    void Start()
    {
        // Loads the previously saved unlocked slots
        LoadUnlocks();
    }

    public void UnlockSlot(int slotNumber)
    {
        // Saves the unlock status on PlayerPrefs
        PlayerPrefs.SetInt("UnlockSlot" + slotNumber, 1);
        PlayerPrefs.Save();

        // Makes correct button enabled/interactable when unlocked
        unlockSlots[slotNumber].interactable = true;
    }

    void LoadUnlocks()
    {
        for (int i = 0; i < unlockSlots.Length; i++)
        {
            // Default is 0 (locked)
            int unlocked = PlayerPrefs.GetInt("UnlockSlot" + i, 0);
            // Default button to be visible but disabled/non-interactable
            unlockSlots[i].interactable = (unlocked == 1); 

            // Saves index
            int slotIndex = i; 
            // Listener to trigger scene transitions and displaying of facts
            unlockSlots[i].onClick.AddListener(() => ShowFact(slotIndex));
        }
    }

    void ShowFact(int slotNumber)
    {
        // Saves selected button's index
        PlayerPrefs.SetInt("SelectedFact", slotNumber); 
        SceneManager.LoadScene("Facts"); 
    }
}
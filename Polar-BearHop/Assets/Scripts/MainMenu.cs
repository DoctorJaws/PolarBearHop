using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Resets the number of collected collectibles from last playthrough
        UnlockObject.collectedInPlaythrough = 0;
        PlayerPrefs.SetInt("CollectedInPlaythrough", 0);

        SceneManager.LoadScene("LevelOne");
    }

    public void Unlocks()
    {
        // Resets the number of collected collectibles from last playthrough
        UnlockObject.collectedInPlaythrough = 0;
        PlayerPrefs.SetInt("CollectedInPlaythrough", 0);
        
        SceneManager.LoadScene("MenuUnlocks");
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitted Game!");
    }
}

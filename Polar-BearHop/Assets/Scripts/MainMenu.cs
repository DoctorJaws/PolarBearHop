using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Unlocks()
    {
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

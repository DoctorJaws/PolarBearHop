using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button[] menuButtons;
    private int selectedButtonIndex = 0;

    void Start()
    {
        HighlightButton();
    }

    void Update()
    {
        HandleInput();
    }

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

    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButtonIndex--;
            if(selectedButtonIndex < 0)
            {
                selectedButtonIndex = menuButtons.Length -1;
            }
            HighlightButton();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButtonIndex++;
            if(selectedButtonIndex >= menuButtons.Length)
            {
                selectedButtonIndex = 0;
            }
            HighlightButton();
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.RightShift))
        {
            menuButtons[selectedButtonIndex].onClick.Invoke();
        }
    }

    void HighlightButton()
    {
        foreach(Button button in menuButtons)
        {
            var colors = button.colors;
            colors.normalColor = Color.white;
            button.colors = colors;
        }

        var selectedColors = menuButtons[selectedButtonIndex].colors;

        selectedColors.normalColor = Color.yellow;
        menuButtons[selectedButtonIndex].colors = selectedColors;
    }
}

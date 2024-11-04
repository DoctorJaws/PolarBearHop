using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuNotification : MonoBehaviour
{
    public Text collectibleNotificationText; 

    void Start()
    {
        int collectedInLastPlaythrough = PlayerPrefs.GetInt("CollectedInPlaythrough", 0);

        if (collectedInLastPlaythrough > 0)
        {
            ShowNotification(collectedInLastPlaythrough);
        }
        else
        {
            collectibleNotificationText.gameObject.SetActive(false); 
        }
    }

    void ShowNotification(int count)
    {
        collectibleNotificationText.text = "You have collected " + count + " collectibles!";
        collectibleNotificationText.gameObject.SetActive(true);
        
        StartCoroutine(HideNotificationAfterDelay());
    }

    IEnumerator HideNotificationAfterDelay()
    {
        yield return new WaitForSeconds(5); 
        collectibleNotificationText.gameObject.SetActive(false);
    }
}

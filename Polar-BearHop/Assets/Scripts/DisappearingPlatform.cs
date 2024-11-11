using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float platformDisappear = 3f;

    void Start()
    {
        Debug.Log("Script for disappearing platform: Confirm");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D called with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with a player: Confirm");
            StartCoroutine(DisappearAfterDelay());
        }
        else
        {
            Debug.Log("Collision with a non-player object: " + collision.gameObject.name);
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        Debug.Log("Starting coroutine to disappear after delay");
        yield return new WaitForSeconds(platformDisappear);
        Debug.Log("Disappearing platform now");
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
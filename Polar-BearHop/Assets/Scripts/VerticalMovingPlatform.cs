using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    public float platformDisappear = 2f;
    public float moveDistance = 2f; 
    public float moveSpeed = 2f; 

    private Vector3 startPosition;

    void Start()
    {
        Debug.Log("Script for disappearing platform: Confirm");
        startPosition = transform.position;
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
        float newY = startPosition.y + Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
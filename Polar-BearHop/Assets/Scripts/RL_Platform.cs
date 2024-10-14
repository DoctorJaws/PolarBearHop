using System.Collections;
using UnityEngine;

public class RL_Platform : MonoBehaviour
{
    public float platformDisappear = 10f;
    public float moveDistance = 2f; // Distance to move left and right
    public float moveSpeed = 2f; // Speed of the movement

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script for disappearing platform: Confirm");
        startPosition = transform.position;
    }

    // Called when another collider enters the trigger collider attached to this object
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

    // Update is called once per frame
    void Update()
    {
        // Move the platform left and right
        float newX = startPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
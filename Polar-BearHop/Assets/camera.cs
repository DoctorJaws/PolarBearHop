using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    private float fixedX;     // To keep the camera's X position fixed

    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("Player transform not assigned. Please assign it in the inspector.");
            return;
        }

        // Store the initial X position of the camera to keep it constant
        fixedX = transform.position.x;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update only the Y position to match the player's Y, and keep X position fixed
            transform.position = new Vector3(fixedX, player.position.y+4, transform.position.z);
        }
    }
}

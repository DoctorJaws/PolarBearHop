using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Array of platform prefabs
    public float spawnInterval = 2f; // Interval between spawns
    public float minYDistance = 1.5f; // Minimum distance between y-levels
    public float maxYDistance = 3f; // Maximum distance between y-levels
    public float xRange = 5f; // Range for x positioning
    public float minPlatformXSeparation = 3f; // Minimum separation between two platforms on the same y-level

    private float lastSpawnY; // Last spawned y position

    void Start()
    {
        SpawnPlatform();
        StartCoroutine(SpawnPlatformsContinuously());
    }

    IEnumerator SpawnPlatformsContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        // Calculate the y position for the new platform(s)
        float newY = lastSpawnY + Random.Range(minYDistance, maxYDistance);

        // Decide if we should spawn one or two platforms at the same y-level
        bool spawnDoublePlatform = Random.value > 0.5f; // 50% chance for two platforms

        if (spawnDoublePlatform)
        {
            // Calculate two distinct x positions for the platforms
            float x1 = Random.Range(-xRange, 0 - minPlatformXSeparation / 2);
            float x2 = Random.Range(minPlatformXSeparation / 2, xRange);

            // Select random platform prefabs
            GameObject platformPrefab1 = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            GameObject platformPrefab2 = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

            // Spawn the platforms at the same y level but separated on the x-axis
            Instantiate(platformPrefab1, new Vector3(x1, newY, 0), Quaternion.identity);
            Instantiate(platformPrefab2, new Vector3(x2, newY, 0), Quaternion.identity);
        }
        else
        {
            // Single platform spawn
            float newX = Random.Range(-xRange, xRange);
            GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Instantiate(platformPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
        }

        // Update lastSpawnY
        lastSpawnY = newY;
    }
}

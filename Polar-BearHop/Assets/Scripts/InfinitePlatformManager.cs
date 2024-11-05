using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs; 
    public float spawnInterval = 2f;
    public float minYDistance = 1.5f; 
    public float maxYDistance = 3f; 
    public float xRange = 5f; 
    public float minPlatformXSeparation = 3f; 

    private float lastSpawnY; 

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
        float newY = lastSpawnY + Random.Range(minYDistance, maxYDistance);

        bool spawnDoublePlatform = Random.value > 0.5f;

        if (spawnDoublePlatform)
        {
            float x1 = Random.Range(-xRange, 0 - minPlatformXSeparation / 2);
            float x2 = Random.Range(minPlatformXSeparation / 2, xRange);

            GameObject platformPrefab1 = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            GameObject platformPrefab2 = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

            Instantiate(platformPrefab1, new Vector3(x1, newY, 0), Quaternion.identity);
            Instantiate(platformPrefab2, new Vector3(x2, newY, 0), Quaternion.identity);
        }
        else
        {
            float newX = Random.Range(-xRange, xRange);
            GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Instantiate(platformPrefab, new Vector3(newX, newY, 0), Quaternion.identity);
        }

        lastSpawnY = newY;
    }
}

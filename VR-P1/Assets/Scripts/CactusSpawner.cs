using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public GameObject[] cactusPrefabs;
    public float spawnInterval = 2f;
    public Transform imageTarget; 
    void Start()
    {
        InvokeRepeating("SpawnCactus", 1f, spawnInterval);
    }

    void SpawnCactus()
    {
        if (imageTarget != null && cactusPrefabs.Length > 0)
        {

            GameObject cactusPrefab = cactusPrefabs[Random.Range(0, cactusPrefabs.Length)];
            Vector3 spawnPosition = imageTarget.TransformPoint(new Vector3(1, 0, 0));
            Instantiate(cactusPrefab, spawnPosition, Quaternion.identity, imageTarget);
        }
    }
}

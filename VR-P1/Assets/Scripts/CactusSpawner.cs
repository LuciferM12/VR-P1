using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float spawnInterval = 2f;
    public Transform imageTarget; // Referencia al Image Target

    void Start()
    {
        InvokeRepeating("SpawnCactus", 1f, spawnInterval);
    }

    void SpawnCactus()
    {
        if (imageTarget != null)
        {
            Vector3 spawnPosition = imageTarget.TransformPoint(new Vector3(1, 0, 0));
            Instantiate(cactusPrefab, spawnPosition, Quaternion.identity, imageTarget);
        }
    }
}
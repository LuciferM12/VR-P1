using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMover : MonoBehaviour
{
    public float speed = 1f;
    private float leftbound = -0.01043059f;
    //public Transform imageTarget; // Referencia al Image Target

    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x < leftbound && gameObject.CompareTag("Cactus"))
        {
            Destroy(gameObject);
        }
    }
}

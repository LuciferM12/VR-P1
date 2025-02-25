using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    private float jumpForce = 0.15f;
    //private Rigidbody rb;
    private bool isGrounded = true;
    private float startY;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        startY = transform.position.y;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //rb.velocity = Vector3.up * jumpForce;
            StartCoroutine(SimulateJump());
            isGrounded = false;
        }
    }

    private IEnumerator SimulateJump()
    {
        float targetY = startY + jumpForce;
        while (transform.position.y < targetY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 0.6f, transform.position.z);
            yield return null;
        }

        // Volver al suelo (o la altura original)
        while (transform.position.y > startY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 0.6f, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        isGrounded = true;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Cactus"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;  // Detiene el juego
        }
    }*/

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Cactus")){
            Debug.Log("Game Over");
            Time.timeScale = 0;  // Detiene el juego
        }
    }
}
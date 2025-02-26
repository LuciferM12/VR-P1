using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    private float jumpForce = 0.3f;//0.15f;
    private float jumpSpeed = 2f;
    //private Rigidbody rb;
    private AudioSource sonidoJugador;

    private bool isGrounded = true;
    private float startY;

    public ParticleSystem polvo;

    public AudioClip sonidoSalto;
    public AudioClip sonidoChoque;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        startY = transform.position.y;
        sonidoJugador = GetComponent<AudioSource>();

    }

    public void Jump()
    {
        if (isGrounded)
        {
            //rb.velocity = Vector3.up * jumpForce;
            StartCoroutine(SimulateJump());
            isGrounded = false;
            polvo.Stop();
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f);
        }
    }

    private IEnumerator SimulateJump()
    {
        isGrounded = false; // 🔥 Evita saltos dobles
        float startY = transform.position.y;
        float targetY = startY + jumpForce;

        // Subir hasta la altura máxima
        while (transform.position.y < targetY)
        {
            transform.position += Vector3.up * (jumpSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f /*0.1f*/); // Pausa antes de bajar

        // Bajar hasta la posición inicial
        while (transform.position.y > startY)
        {
            transform.position -= Vector3.up * (jumpSpeed * Time.deltaTime);

            if (transform.position.y < startY) // 🔥 Corrige la posición exacta
            {
                transform.position = new Vector3(transform.position.x, startY, transform.position.z);
            }

            yield return null;
        }
        isGrounded = true; // 🔥 Habilita el siguiente salto
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            polvo.Play();
        }

        if (collision.gameObject.CompareTag("Cactus"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;  // Detiene el juego
            polvo.Stop();
            sonidoJugador.PlayOneShot(sonidoChoque, 1.0f);
        }
    }*/

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Cactus")){
            Debug.Log("Game Over");
            Time.timeScale = 0;  // Detiene el juego
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody rb;
    private AudioSource sonidoJugador;
    private bool isGrounded = true;

    public ParticleSystem polvo;

    public AudioClip sonidoSalto;
    public AudioClip sonidoChoque;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sonidoJugador = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
            polvo.Stop();
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
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
    }
}
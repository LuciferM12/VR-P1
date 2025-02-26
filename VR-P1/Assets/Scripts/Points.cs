using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text scoreText; 
    public float timeScale = 5.0f; // Velocidad del tiempo (1 = normal, 2 = doble velocidad, etc.)
    public float blinkDuration = 0.1f; // Duración de cada parpadeo
    public int blinkCount = 3; // Número de veces que parpadea

    private float startTime;
    private int score = 0;
    private bool isBlinking = false;

    void Start()
    {
        startTime = Time.time;
        scoreText.text = "00000"; // Inicializa el texto con ceros
    }

    void Update()
    {
        // Calcula el tiempo transcurrido, ajustado por la velocidad del tiempo
        float elapsedTime = (Time.time - startTime) * timeScale;

        // Convierte el tiempo transcurrido a puntaje (1 punto por segundo)
        int newScore = Mathf.FloorToInt(elapsedTime);

        // Si el puntaje cambia, actualiza el texto
        if (newScore != score)
        {
            score = newScore;
            UpdateScoreText();

            // Parpadea cada 100 puntos
            if (score % 100 == 0 && score != 0)
            {
                StartCoroutine(BlinkText());
            }
        }
    }

    void UpdateScoreText()
    {
        // Formatea el puntaje con ceros a la izquierda (ejemplo: 00042)
        scoreText.text = score.ToString("00000");
    }

    System.Collections.IEnumerator BlinkText()
    {
        if (isBlinking) yield break; // Evita múltiples parpadeos simultáneos

        isBlinking = true;

        // Repite el parpadeo varias veces
        for (int i = 0; i < blinkCount; i++)
        {
            scoreText.enabled = false; // Apaga el texto
            yield return new WaitForSeconds(blinkDuration);

            scoreText.enabled = true; // Prende el texto
            yield return new WaitForSeconds(blinkDuration);
        }

        isBlinking = false;
    }
}


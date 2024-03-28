using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOOrbit : MonoBehaviour
{
    public Transform target; // El objeto alrededor del cual se orbitar�
    public float orbitSpeed = 50f; // Velocidad de la �rbita
    public bool clockwiseOrbit = true; // Direcci�n de la �rbita (true: sentido del reloj, false: contra el reloj)
    public float pauseEvery = 0f; // Frecuencia de pausa (0 para no pausar)
    public float pauseTime = 1f; // Duraci�n de la pausa

    private Vector2 orbitCenter; // Centro de la �rbita
    private float nextPauseTime; // Tiempo para la pr�xima pausa
    private bool isPaused = false; // Estado de pausa

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo para la �rbita.");
            enabled = false; // Desactiva el script si no hay objetivo
            return;
        }

        orbitCenter = target.position; // Establece el centro de la �rbita como la posici�n del objetivo
        nextPauseTime = Time.time + pauseEvery; // Establece el tiempo para la pr�xima pausa
    }

    void Update()
    {
        if (target != null && !isPaused)
        {
            // Determina la direcci�n de la rotaci�n
            int rotationDirection = clockwiseOrbit ? 1 : -1;

            // Calcula la posici�n orbital
            Vector2 offset = (Vector2)transform.position - orbitCenter;
            Vector2 direction = Quaternion.Euler(0, 0, rotationDirection * orbitSpeed * Time.deltaTime) * offset;
            transform.position = orbitCenter + direction;

            // Comprueba si se debe realizar una pausa
            if (pauseEvery > 0 && Time.time >= nextPauseTime)
            {
                isPaused = true;
                nextPauseTime = Time.time + pauseEvery + pauseTime; // Actualiza el tiempo para la pr�xima pausa
                Invoke("ResumeOrbit", pauseTime); // Programa la reanudaci�n de la �rbita despu�s de la pausa
            }
        }
    }

    // M�todo para reanudar la �rbita despu�s de la pausa
    private void ResumeOrbit()
    {
        isPaused = false;
    }
}

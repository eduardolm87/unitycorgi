using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOOrbit : MonoBehaviour
{
    public Transform target; // El objeto alrededor del cual se orbitará
    public float orbitSpeed = 50f; // Velocidad de la órbita
    public bool clockwiseOrbit = true; // Dirección de la órbita (true: sentido del reloj, false: contra el reloj)
    public float pauseEvery = 0f; // Frecuencia de pausa (0 para no pausar)
    public float pauseTime = 1f; // Duración de la pausa

    private Vector2 orbitCenter; // Centro de la órbita
    private float nextPauseTime; // Tiempo para la próxima pausa
    private bool isPaused = false; // Estado de pausa

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo para la órbita.");
            enabled = false; // Desactiva el script si no hay objetivo
            return;
        }

        orbitCenter = target.position; // Establece el centro de la órbita como la posición del objetivo
        nextPauseTime = Time.time + pauseEvery; // Establece el tiempo para la próxima pausa
    }

    void Update()
    {
        if (target != null && !isPaused)
        {
            // Determina la dirección de la rotación
            int rotationDirection = clockwiseOrbit ? 1 : -1;

            // Calcula la posición orbital
            Vector2 offset = (Vector2)transform.position - orbitCenter;
            Vector2 direction = Quaternion.Euler(0, 0, rotationDirection * orbitSpeed * Time.deltaTime) * offset;
            transform.position = orbitCenter + direction;

            // Comprueba si se debe realizar una pausa
            if (pauseEvery > 0 && Time.time >= nextPauseTime)
            {
                isPaused = true;
                nextPauseTime = Time.time + pauseEvery + pauseTime; // Actualiza el tiempo para la próxima pausa
                Invoke("ResumeOrbit", pauseTime); // Programa la reanudación de la órbita después de la pausa
            }
        }
    }

    // Método para reanudar la órbita después de la pausa
    private void ResumeOrbit()
    {
        isPaused = false;
    }
}

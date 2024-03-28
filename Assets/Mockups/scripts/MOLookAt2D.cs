using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOLookAt2D : MonoBehaviour
{
    public Transform target; // El objeto al que se debe mirar

    void Update()
    {
        if (target != null)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 direction = target.position - transform.position;
            direction.z = 0f; // Asegúrate de que la dirección esté en el plano 2D

            // Calcula la rotación para mirar hacia el objetivo
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Aplica la rotación al objeto
            transform.rotation = rotation;
        }
    }
}

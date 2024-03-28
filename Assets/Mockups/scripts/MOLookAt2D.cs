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
            // Calcula la direcci�n hacia el objetivo
            Vector3 direction = target.position - transform.position;
            direction.z = 0f; // Aseg�rate de que la direcci�n est� en el plano 2D

            // Calcula la rotaci�n para mirar hacia el objetivo
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Aplica la rotaci�n al objeto
            transform.rotation = rotation;
        }
    }
}

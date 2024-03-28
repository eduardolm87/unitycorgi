using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONoAngleChange : MonoBehaviour
{
    private Quaternion initialRotation; // Rotaci�n inicial del objeto hijo

    void Start()
    {
        // Almacenar la rotaci�n inicial al inicio
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Restaurar la rotaci�n inicial en cada actualizaci�n
        transform.rotation = initialRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONoAngleChange : MonoBehaviour
{
    private Quaternion initialRotation; // Rotación inicial del objeto hijo

    void Start()
    {
        // Almacenar la rotación inicial al inicio
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Restaurar la rotación inicial en cada actualización
        transform.rotation = initialRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Racing : MonoBehaviour
{
    [Header("Objetos en Competencia")]
    [SerializeField] private Transform objetoMRU;
    [SerializeField] private Transform objetoMRUV; 

    [Header("Parámetros MRU")]
    [SerializeField] private float speedConstantMRU = 5f; 
    [SerializeField] private float elapsedTimeMRU; 

    [Header("Parámetros MRUV")]
    [SerializeField] private float speedInitialMRUV = 0f;
    [SerializeField] private float elapsedTimeMRUV; 
    [SerializeField] private float accelerationMRUV = 2f; 

    private float tiempoActual = 0f; 

    private void Update()
    {
        if (tiempoActual < 10f)
        {
            tiempoActual += Time.deltaTime;

            elapsedTimeMRU = tiempoActual; 
            float xMRU = speedConstantMRU * elapsedTimeMRU; 
            objetoMRU.position = new Vector3(xMRU, objetoMRU.position.y, objetoMRU.position.z);

            elapsedTimeMRUV = tiempoActual; 
            float xMRUV = speedInitialMRUV * elapsedTimeMRUV + 0.5f * accelerationMRUV * elapsedTimeMRUV * elapsedTimeMRUV; 
            objetoMRUV.position = new Vector3(xMRUV, objetoMRUV.position.y, objetoMRUV.position.z);
        }
    }
}

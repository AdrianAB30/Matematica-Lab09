using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement_MRU : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed = 2f; 
    [SerializeField] private TMP_Text[] distanceTexts; 
    private int currentPointIndex = 0;
    private float journeyLength; 

    private void Start()
    {
        SetInitialPosition();
        CalculateJourneyLength();
    }

    private void Update()
    {
        if (patrolPoints.Length > 0)
        {
            Patrol();
            UpdateDistanceTexts();
        }
    }

    private void SetInitialPosition()
    {
        transform.position = patrolPoints[currentPointIndex].position;
    }

    private void CalculateJourneyLength()
    {
        journeyLength = Vector3.Distance(patrolPoints[currentPointIndex].position, patrolPoints[(currentPointIndex + 1) % patrolPoints.Length].position);
    }

    private void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];

        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            UpdateToNextPoint();
            CalculateJourneyLength();
        }
    }

    private void UpdateToNextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; 
    }

    private void UpdateDistanceTexts()
    {
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, patrolPoints[i].position);
            float estimatedTime = distance / speed; 

            distanceTexts[i].text = "Tiempo al siguiente punto: " + estimatedTime.ToString("F2") + "s";
        }
    }
}

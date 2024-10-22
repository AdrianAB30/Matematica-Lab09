using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUV_Movement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float acceleration;
    [SerializeField] private float decelerationDistance;
    [SerializeField] private float stopDistance;
    [SerializeField] private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > stopDistance)
        {
            if (distanceToTarget >= decelerationDistance)
            {
                velocity += direction * acceleration * Time.deltaTime;
            }
            else
            {
                float decelerationFactor = distanceToTarget / decelerationDistance;
                velocity = velocity * decelerationFactor; 
            }

            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    private Vector3 CalculatePosition(Vector3 initialVelocity, float time, Vector3 acceleration)
    {
        return initialVelocity * time + 0.5f * acceleration * time * time;
    }
}

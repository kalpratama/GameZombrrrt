using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemy : MonoBehaviour
{
    public float patrolRadius = 20f;  // Radius within which the enemy will patrol

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolTarget;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNewPatrolTarget();
    }

    void Update()
    {
        // Move to the patrol target
        navMeshAgent.SetDestination(patrolTarget);

        // Check if the enemy has reached the patrol target
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            SetNewPatrolTarget();
        }
    }

    void SetNewPatrolTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, patrolRadius, -1);
        patrolTarget = navHit.position;
    }
}

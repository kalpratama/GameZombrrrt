using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    public float detectionRadius = 10f; // Radius within which the enemy detects the player
    public float patrolRadius = 20f; // Radius within which the enemy can patrol

    private Vector3 originalPosition;
    private bool isPatrolling = true;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
        StartCoroutine(Patrol());
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            StopCoroutine(Patrol());
            isPatrolling = false;
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            if (!isPatrolling)
            {
                StartCoroutine(Patrol());
                isPatrolling = true;
            }
        }
    }

    IEnumerator Patrol()
    {
        while (isPatrolling)
        {
            Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
            randomDirection += originalPosition;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
            Vector3 finalPosition = hit.position;

            navMeshAgent.SetDestination(finalPosition);

            yield return new WaitForSeconds(Random.Range(3f, 7f)); // Wait for a random amount of time before moving again
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomMovement : MonoBehaviour
{
    public float movementRadius = 10f;  // The maximum distance the agent can move from its initial position
    private Vector3 initialPosition;   // The initial position of the agent
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    private void Start()
    {
        // Get the initial position of the agent
        initialPosition = transform.position;

        // Get the NavMeshAgent component attached to the agent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Start the random movement coroutine
        StartCoroutine(RandomMove());
    }

    private System.Collections.IEnumerator RandomMove()
    {
        while (true)
        {
            // Generate a random direction within the movement radius
            Vector3 randomDirection = Random.insideUnitSphere * movementRadius;

            // Calculate the target position by adding the random direction to the initial position
            Vector3 targetPosition = initialPosition + randomDirection;

            // Check if the target position is within the NavMesh
            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(targetPosition, out navMeshHit, movementRadius, NavMesh.AllAreas))
            {
                // Set the destination of the NavMeshAgent to the target position
                navMeshAgent.SetDestination(navMeshHit.position);
            }

            // Wait for the agent to reach the destination or until a new target position is set
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }


}

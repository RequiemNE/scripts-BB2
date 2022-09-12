using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public bool followPlayer = false;

    private Vector3 startPos;
    private GameObject player;
    private NavMeshAgent agent;

    private void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        // SLIGHT pause before moving back?
        if (followPlayer)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = startPos;
        }
    }
}
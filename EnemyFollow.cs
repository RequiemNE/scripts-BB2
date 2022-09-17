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
            StopCoroutine("MoveBackToStart");
            agent.destination = player.transform.position;
        }
        else if (!followPlayer && transform.position != startPos)
        {
            StartCoroutine("MoveBackToStart");
        }
    }

    private IEnumerator MoveBackToStart()
    {
        yield return new WaitForSeconds(3f);
        agent.destination = startPos;
    }
}
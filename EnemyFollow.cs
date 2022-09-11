using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool followPlayer = false;
    [SerializeField] private float speed = 1.0f;

    private Vector3 startPos;
    private GameObject player;
    private Rigidbody rb;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void FixedUpdate()
    {
        // if follow player = false
        // return to start pos
        if (followPlayer)
        {
            float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            rb.MovePosition(player.transform.position);
        }
    }
}
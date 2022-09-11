using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool followPlayer = false;
    [SerializeField] private float speed = 1.0f;

    private Vector3 startPos;
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        // get position
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    private void Update()
    {
        // if follow player = false
        // return to start pos
        if (followPlayer)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }
}
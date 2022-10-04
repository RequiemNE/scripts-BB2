using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Car : MonoBehaviour
{
    public int playerID = 0;
    private Player player;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxRotation = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float turnClamp = 5f;
    private Vector3 moveVector;
    private Rigidbody rb;
    private float yPos;

    // Start is called before the first frame update
    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        yPos = transform.position.y;

        // REDO all of below. Start with side to side movement and add the rotation in later.

        //transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        float turnVector = moveVector.x * turnSpeed;

        //float clampX = Mathf.Clamp(transform.position.x, -turnClamp, turnClamp);
        //Debug.Log(clampX);
        // transform.position += new Vector3(turnVector, 0, 0) * Time.deltaTime;
        //Debug.Log(transform.position.x);
        if (transform.position.x < turnClamp + 1 && transform.position.x > -turnClamp - 1 && moveVector.x != 0.0f)
        {
            rb.AddForce(new Vector3(turnVector, 0, 0));
        }
        if (transform.position.x > turnClamp)
        {
            Debug.Log("went over clamp");
            float moveBack = transform.position.x - 0.2f;
            transform.position = new Vector3(turnClamp, yPos, 0);
        }
        if (transform.position.x < -turnClamp)
        {
            Debug.Log("went under clamp");
            float moveBack = transform.position.x + 0.2f;
            transform.position = new Vector3(-turnClamp, yPos, 0);
        }
    }
}
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
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float turnClamp = 5f;
    private Vector3 moveVector;
    private Rigidbody rb;
    private float yPos;
    private float turnVector;

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

        Movement();

        Rotation();
    }

    private void Movement()
    {
        turnVector = moveVector.x * turnSpeed;
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        if (transform.position.x < turnClamp + 1 && transform.position.x > -turnClamp - 1 && moveVector.x != 0.0f)
        {
            rb.AddForce(new Vector3(turnVector, 0, 0));
        }

        // clamp right
        if (transform.position.x > turnClamp)
        {
            float moveBack = transform.position.x - 0.2f;
            transform.position = new Vector3(turnClamp, yPos, transform.position.z);
        }

        // clamp left
        if (transform.position.x < -turnClamp)
        {
            float moveBack = transform.position.x + 0.2f;
            transform.position = new Vector3(-turnClamp, yPos, transform.position.z);
        }
    }

    private void Rotation()
    {
        // euler angles is only 0 - 360, so had to tweak the if statement.
        if (transform.rotation.eulerAngles.y < maxRotation && moveVector.x != 0.0f ||
            transform.rotation.eulerAngles.y > 359.9 - maxRotation && moveVector.x != 0.0f)
        {
            float newRot = moveVector.x * rotateSpeed;
            gameObject.transform.Rotate(new Vector3(0, newRot, 0), Space.World);
        }

        // rotate clamp right
        if (moveVector.x == 0.0f && transform.rotation.eulerAngles.y > 0)
        {
            float newRot = transform.rotation.y * -rotateSpeed * 4;
            gameObject.transform.Rotate(new Vector3(0, newRot, 0), Space.World);
        }

        //rotate clamp left
        if (moveVector.x == 0.0f && transform.rotation.eulerAngles.y < 0)
        {
            float newRot = transform.rotation.y * -rotateSpeed * 4;
            gameObject.transform.Rotate(new Vector3(0, newRot, 0), Space.World);
        }
    }
}
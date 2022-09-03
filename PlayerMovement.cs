using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private const float MAXSPEED = 50;
    [SerializeField] private bool canMove;
    public int playerID = 0;

    private Player player;
    private CharacterController charController;
    private Rigidbody rb;
    private Vector3 moveVector;
    private bool jump;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerID);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            GetInput();
            ProcessInput();
        }
    }

    private void ProcessInput()
    {
        if (moveVector.x != 0.0f || moveVector.z != 0.0f)
        {
            rb.AddForce(moveVector * moveSpeed * Time.deltaTime);
            Vector3 vel = rb.velocity;
            Debug.Log("Velocity is: " + vel);
        }
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.z = player.GetAxis("Move Vertical");
        jump = player.GetButtonDown("Jump");
    }
}
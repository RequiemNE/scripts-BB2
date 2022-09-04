using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float maxVelocity = 10;
    [SerializeField] private bool canMove;
    public int playerID = 0;

    private Player player;
    private CharacterController charController;
    private Rigidbody rb;
    private Vector3 moveVector;
    private Vector3 currentVelocity;

    // jump is used to as the variable assigned to Rewired Jump action.
    // canJump is the variable for game logic.
    public bool jump, canJump;

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
        if (canJump)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.8f))
        {
            canJump = true;

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            //Debug.Log("Hit!");
        }
        else
        {
            canJump = false;
        }
    }

    private void ProcessInput()
    {
        currentVelocity = rb.velocity;
        // Ensure both X and Y velocity is not more than 10 or less than -10
        if (moveVector.x != 0.0f && currentVelocity.x < maxVelocity && currentVelocity.x > -maxVelocity
            || moveVector.z != 0.0f && currentVelocity.z < maxVelocity && currentVelocity.z > -maxVelocity)
        {
            rb.AddForce(moveVector * moveSpeed * Time.deltaTime);
        }
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.z = player.GetAxis("Move Vertical");
        jump = player.GetButtonDown("Jump");
    }

    private void Jump()
    {
        currentVelocity = rb.velocity;
        if (jump)
        {
            Debug.Log("jump pressed.");
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }
    }

    // void StopMomentum
    //       on respawn stop all momentum.
}
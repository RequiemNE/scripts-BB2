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
        // raycast below.
        // if raycast not hitting floor
        //      cantJump
        // else
        //      jump
    }

    // void StopMomentum
    // on respawn stop all momentum.
}
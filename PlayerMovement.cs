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
    private bool jump, canJump;

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
        Vector3 rayDir = Vector3.down;
        if (Physics.Raycast(transform.position, rayDir, out hit, 0.8f))
        {
            canJump = true;

            Debug.DrawRay(transform.position, rayDir * hit.distance, Color.red);
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
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }
    }

    public void StopMomentum()
    {
        canJump = false;
        canMove = false;
        rb.velocity = Vector3.zero;
        StartCoroutine("EnableMovement");
    }

    private IEnumerator EnableMovement()
    {
        // added first WaitForSec to zero velocity again after respawn from PlaterStatus.cs
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(2f);
        canMove = true;
        canJump = true;
    }
}
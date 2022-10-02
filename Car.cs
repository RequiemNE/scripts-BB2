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
    private Vector3 moveVector;
    public Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    private void Update()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        //transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        // max rotation -5 to 5 on y
        Debug.Log(moveVector.x);
        Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;

        if (moveVector.x != 0.0f && currentRotation.y <= maxRotation && currentRotation.y >= -maxRotation)
        {
            gameObject.transform.Rotate(0, moveVector.x, 0, Space.World);
        }
        if (moveVector.x <= 0.0f && currentRotation.y > maxRotation)
        {
            float rotateBack = currentRotation.y - maxRotation;
            gameObject.transform.Rotate(0, rotateBack, 0, Space.World);
        }
    }
}
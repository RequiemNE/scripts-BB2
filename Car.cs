using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Car : MonoBehaviour
{
    public int playerID = 0;
    private Player player;

    [SerializeField] private float speed = 10f;
    private Vector3 moveVector;

    // Start is called before the first frame update
    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    private void Update()
    {
        moveVector.x = player.GetAxis("Move Horizontal");

        // max rotation -5 to 5 on y
    }
}
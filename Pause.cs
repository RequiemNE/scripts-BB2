using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Pause : MonoBehaviour
{
    public int playerID = 0;
    private Player player;

    private bool pauseInput;
    private bool pause = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    private void Update()
    {
        pauseInput = player.GetButtonDown("Pause");
    }

    private void PauseMenu()
    {
        if (pause)
        {
        }
    }
}
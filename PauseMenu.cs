using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settings;

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

    private void Pause()
    {
        if (pause)
        {
            // stop player and enemies.
            // load menu
            // settings false.
        }
    }

    private void MainMenu()
    {
        // load main menu
    }

    private void Settings()
    {
        // root false
    }
}
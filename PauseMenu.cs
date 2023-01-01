using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject mainMenuButton;

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
        Pause();
    }

    private void Pause()
    {
        if (pauseInput)
        {
            if (pause == false)
            {
                pause = true;
            }
            else
            {
                pause = false;
            }
        }
        if (pause)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            // stop player and enemies.
            // load menu
            // settings false.
            pauseMenu.SetActive(true);
            resumeButton.SetActive(true);
            mainMenuButton.SetActive(true);
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            AudioListener.pause = false;
            pauseMenu.SetActive(false);
            resumeButton.SetActive(false);
            mainMenuButton.SetActive(false);
        }
    }

    // BUTTON FUCNTIONS -------------------------

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Resume()
    {
        pause = false;
    }
}
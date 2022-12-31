using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject settingsButton;
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
        pauseMenu.SetActive(false);
        settings.SetActive(false);
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
            Debug.Log("pause");
            // stop player and enemies.
            // load menu
            // settings false.
            pauseMenu.SetActive(true);
            settings.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(false);
            settings.SetActive(false);
        }
    }

    // BUTTON FUCNTIONS -------------------------

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Settings()
    {
        // root false
        pauseMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(true);
        // resume elements.
    }
}
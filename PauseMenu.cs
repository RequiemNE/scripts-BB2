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
    [SerializeField] private GameObject resolutionDropDown;
    [SerializeField] private GameObject volumeSlider;
    [SerializeField] private GameObject saveButton;

    public int playerID = 0;
    private Player player;

    private bool pauseInput;
    private bool pause = false;
    private bool rootMenu = false;
    private bool settingsMenu = false;

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
            Time.timeScale = 0;
            Cursor.visible = true;
            // stop player and enemies.
            // load menu
            // settings false.
            pauseMenu.SetActive(true);
            resumeButton.SetActive(true);
            settingsButton.SetActive(true);
            mainMenuButton.SetActive(true);
            settings.SetActive(true);
            resolutionDropDown.SetActive(false);
            volumeSlider.SetActive(false);
            saveButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            resumeButton.SetActive(false);
            settingsButton.SetActive(false);
            mainMenuButton.SetActive(false);
            resolutionDropDown.SetActive(false);
            volumeSlider.SetActive(false);
            saveButton.SetActive(false);
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
        Debug.Log("Hit settings");
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);
        resolutionDropDown.SetActive(true);
        volumeSlider.SetActive(true);
        saveButton.SetActive(true);
        settingsButton.SetActive(false);
    }

    public void Resume()
    {
        pause = false;
        // resume elements.
    }

    public void SaveSettings()
    {
    }
}
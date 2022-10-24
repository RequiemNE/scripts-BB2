using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject quit;

    // Start is called before the first frame update
    private void Start()
    {
        // get rewired and be able to use. up/down for nav. Jump for go.
        // maybe make new profile for menu.
        startGame.SetActive(true);
        levelSelect.SetActive(true);
        quit.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        // if levelSelect
        // hide startGame and Quit.
        // Show levels.

        // if startGame.
        // Load level1.

        // if quit.
        // quit.
    }

    public void StartGame()
    {
        Debug.Log("Pressed start");
    }

    public void LevelSelect()
    {
        Debug.Log("Pressed LS");
    }

    public void Quit()
    {
        Debug.Log("Pressed quit");
    }
}
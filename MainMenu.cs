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
    [SerializeField] private GameObject[] levels;
    [SerializeField] private Sprite[] lvlImageClear;
    [SerializeField] private Sprite[] lvlImageBlur;
    [SerializeField] private float startTime = 2f;

    private bool rootMenu = true;
    private bool levelSelectMenu = false;

    // Start is called before the first frame update
    private void Start()
    {
        // get rewired and be able to use. up/down for nav. Jump for go.
        // maybe make new profile for menu.

        // check save data. If not completed blur level image.
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

        if (rootMenu)
        {
            startGame.SetActive(true);
            levelSelect.SetActive(true);
            quit.SetActive(true);
        }
        if (!rootMenu)
        {
            startGame.SetActive(false);
            levelSelect.SetActive(false);
            quit.SetActive(false);
        }

        if (levelSelectMenu)
        {
            if (levels != null && levels.Length > 0)
            {
                foreach (GameObject i in levels)
                {
                    i.SetActive(true);
                }
            }
        }
    }

    // BUTTON FUNCTIONS ---------------------------------------

    public void StartGame()
    {
        StartCoroutine("StartCoroutine");
    }

    public void LevelSelect()
    {
        rootMenu = false;
        levelSelectMenu = true;
    }

    public void Quit()
    {
        Debug.Log("Pressed quit");
        Application.Quit(0);
    }

    // COROUTINES -------------------------------------------

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadSceneAsync("Level-1", LoadSceneMode.Single);
    }
}
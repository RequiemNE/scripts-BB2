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
    [SerializeField] private GameObject backButton;
    [SerializeField] private Button[] levels;
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
        if (rootMenu)
        {
            startGame.SetActive(true);
            levelSelect.SetActive(true);
            quit.SetActive(true);
            backButton.SetActive(false);
            if (levels != null && levels.Length > 0)
            {
                foreach (Button i in levels)
                {
                    i.gameObject.SetActive(false);
                }
            }
        }
        if (!rootMenu)
        {
            startGame.SetActive(false);
            levelSelect.SetActive(false);
            quit.SetActive(false);
            backButton.SetActive(true);
        }

        if (levelSelectMenu)
        {
            LevelSelectLogic();
        }
    }

    private void LevelSelectLogic()
    {
        rootMenu = false;
        if (levels != null && levels.Length > 0)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].gameObject.SetActive(true);
                levels[i].image.sprite = lvlImageBlur[i];
                /*
                    if level complete
                        unblur image
                        can load level - start coroutine and pass int i
                    if level not complete
                        blur images
                        cant load. Makes buzzer noise or something.
                 */
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

    public void BackButton()
    {
        levelSelectMenu = false;
        rootMenu = true;
    }

    // COROUTINES -------------------------------------------

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadSceneAsync("Level-1", LoadSceneMode.Single);
    }

    private IEnumerator LoadLevel(int level)
    {
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
    }
}
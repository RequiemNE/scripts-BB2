using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject clearData;
    [SerializeField] private GameObject backButton;
    [SerializeField] private Button[] levels;
    [SerializeField] private Sprite[] lvlImageClear;
    [SerializeField] private Sprite[] lvlImageBlur;
    [SerializeField] private float startTime = 2f;
    [SerializeField] private AudioClip cantSound;

    private bool rootMenu = true;
    private bool levelSelectMenu = false;
    private bool[] lvlArr = new bool[5];

    private SavedLevels savedLevels = new SavedLevels();
    private AudioSource audioS;

    // Start is called before the first frame update
    private void Start()
    {
        // get rewired and be able to use. up/down for nav. Jump for go.
        // maybe make new profile for menu.
        audioS = GetComponent<AudioSource>();
        Cursor.visible = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    private void Update()
    {
        if (rootMenu)
        {
            startGame.SetActive(true);
            levelSelect.SetActive(true);
            quit.SetActive(true);
            clearData.SetActive(true);
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
            clearData.SetActive(false);
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
            CheckLevel();
        }
    }

    private void CheckLevel()
    {
        CompareLevels();
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].gameObject.SetActive(true);
            levels[i].image.sprite = lvlImageBlur[i];
            if (lvlArr[i] == true)
            {
                levels[i].image.sprite = lvlImageClear[i];
            }
        }
    }

    private void CompareLevels()
    {
        SaveGame saveGame = gameObject.GetComponent<SaveGame>();

        string saveFile = Application.persistentDataPath + "/SaveLevels.json";
        // break out of function if file doesn't exist.
        if (!File.Exists(saveFile))
        {
            return;
        }
        string fileContents = File.ReadAllText(saveFile);
        savedLevels = JsonUtility.FromJson<SavedLevels>(fileContents);

        // Quite a horrid bit of code, but it does the job.
        if (savedLevels.l1 == true)
        {
            lvlArr[0] = true;
        }
        if (savedLevels.l2 == true)
        {
            lvlArr[1] = true;
        }
        if (savedLevels.l3 == true)
        {
            lvlArr[2] = true;
        }
        if (savedLevels.l4 == true)
        {
            lvlArr[3] = true;
        }
        if (savedLevels.l5 == true)
        {
            lvlArr[4] = true;
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
        Application.Quit(0);
    }

    public void BackButton()
    {
        levelSelectMenu = false;
        rootMenu = true;
    }

    public void LaunchLevel(Button button)
    {
        // If level image is using colour version, then can play level.
        string imageName = button.image.sprite.name.ToString();
        if (imageName.Contains("colour"))
        {
            StartCoroutine(LoadLevel(button.name));
        }
        else
        {
            audioS.PlayOneShot(cantSound);
        }
    }

    public void ClearSave()
    {
        SaveGame saveGame = gameObject.GetComponent<SaveGame>();
        saveGame.ClearSave();
        // AYS y/n
        // clear save from script.
    }

    // COROUTINES -------------------------------------------

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadSceneAsync("Level-1", LoadSceneMode.Single);
    }

    private IEnumerator LoadLevel(string level)
    {
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
    }
}

// NEW CLASSES -------------------------------------------

[System.Serializable]
public class SavedLevels
{
    public bool l1;
    public bool l2;
    public bool l3;
    public bool l4;
    public bool l5;
}
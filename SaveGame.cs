using System.Collections;
using System.Collections.Generic;
using System.IO; // for file manipulation
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    // path to save file
    private string saveFile;

    private Levels levels = new Levels();

    private void Awake()
    {
        // placed in awake as Unity has to first generate persistant data.
        saveFile = Application.persistentDataPath + "/SaveLevels.json";
    }

    public void ReadFile()
    {
        // Check if file exists.
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);
            levels = JsonUtility.FromJson<Levels>(fileContents);
            Debug.Log(levels.l1 + " " + levels.l2);
        }
    }

    public void WriteFile()
    {
        string jsonString = JsonUtility.ToJson(levels);
        File.WriteAllText(saveFile, jsonString);
    }

    public void Save(int levelNumber)
    {
        ReadFile();

        switch (levelNumber)
        {
            case 1:
                levels.l1 = true;
                break;

            case 2:
                levels.l2 = true;
                break;

            case 3:
                levels.l3 = true;
                break;

            case 4:
                levels.l4 = true;
                break;

            case 5:
                levels.l5 = true;
                break;

            default:
                Debug.Log("Level not recognised. Level " + levelNumber +
           "was submitted to Save function in SaveGame.cs");
                break;
        }

        WriteFile();

        //Debug.Log("Level not recognised. Level " + levelNumber +
        //   "was submitted to Save function in SaveGame.cs");
    }
}

[System.Serializable]
public class Levels
{
    public bool l1;
    public bool l2;
    public bool l3;
    public bool l4;
    public bool l5;
}
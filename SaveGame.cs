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
            // work with json file.
        }
    }

    public void WriteFile()
    {
        File.WriteAllText(saveFile, jsonString);
    }
}

[System.Serializable]
public class Levels
{
    public bool level;
}
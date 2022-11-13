using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private int level1, level2, level3, level4, level5;

    public void SaveLevel(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 1:
                level1 = SaveState(level1);
                break;

            case 2:
                level2 = SaveState(level2);
                break;

            case 3:
                level3 = SaveState(level3);
                break;

            case 4:
                level4 = SaveState(level4);
                break;

            case 5:
                level5 = SaveState(level5);
                break;

            default:
                Debug.Log("Error, " + sceneIndex + " is not part of switch statement.");
                break;
        }
    }

    private int SaveState(int level)
    {
        if (level != 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int CheckLevel(int level)
    {
        switch (level)
        {
            case 1:
                return level1;

            case 2:
                return level1;

            case 3:
                return level1;

            case 4:
                return level1;

            case 5:
                return level1;

            default:
                return 5;
        }
    }

    // level 1 - 5
    // playerPrefs.setInt("level1, 1);
    // 1, 0 for true or false.
    // foreach level in levels
    //playerPrefs(getInt)
    //if int == 1
    // use non-blur image && can select level.
    //else
    // blur image and can't select.
}
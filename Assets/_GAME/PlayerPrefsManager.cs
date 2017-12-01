using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string CURR_LEVEL = "current_level";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master Volume not between 0 and 1");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }


    public static void UnlockLevel(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true
        } else {
            Debug.LogError("Trying to unlock level not in build settings");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt( LEVEL_KEY + level.ToString() );
        bool isLevelUnlocked = (levelValue == 1);

        if (level < SceneManager.sceneCountInBuildSettings)
        {
            return isLevelUnlocked;
        } else {
            Debug.LogError("Trying to unlock level not in build settings");
            return false;
        }
    }


    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty not between 1 and 3");
        }
    }

    public static float getDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetCurrentLevel(string level)
    {
        PlayerPrefs.SetString(CURR_LEVEL, level);
    }

    public static string getCurrentLevel()
    {
        return PlayerPrefs.GetString(CURR_LEVEL);
    }
}

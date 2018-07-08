﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level unlocked_";

    public static void SetMasterVolume(float vol){
        if (vol > 0f && vol < 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, vol);
        } else {
            Debug.LogError("Master volume out of range");
        }

    }

    public static float getMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int lvl){
        if (lvl <= Application.levelCount - 1){
            PlayerPrefs.SetInt(LEVEL_KEY + lvl.ToString(), 1);
        } else {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int lvl){
        if (lvl <= Application.levelCount - 1)
        {
            int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + lvl.ToString());
            return levelValue == 1;
        }
        else{
            Debug.LogError("Trying to query level not in build order");
        }
        return false;
    }

    public static void SetDifficulty(float diff){
        if (diff >= 1f && diff <= 3f){
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        } else {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    private void Start()
    {
        Load();
    }

    public void AddLevel()
    {
        currentLevel += 1;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("currentLevel", currentLevel);
    }

    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }
}

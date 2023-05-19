using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFalse : MonoBehaviour
{
    private int restart;
    public int Restart => restart;

    private void Start()
    {
        Load();
    }
    private void Update()
    {
        Save();
    }

    public void Click()
    {
        if(restart == 0)
        {
            restart = 1;
        }
        /*
        else // DBG
        {
            restart = 0;
        }
        */
    }

    private void Save()
    {
        PlayerPrefs.SetInt("R", restart);

    }

    private void Load()
    {
        restart = PlayerPrefs.GetInt("R");
    }
}

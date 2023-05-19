using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSave : MonoBehaviour
{
    [SerializeField] LevelFalse levelFalse;
    [SerializeField] GameObject menu;

    void Start()
    {
        State();
    }

    private void State()
    {
        menu.SetActive(false);
        /*
        if(restart == 1)
        {
            menu.SetActive(false);
        }
        */
        if(levelFalse.Restart == 0)
        {
            menu.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    [SerializeField] LevelFalse levelFalse;
    [SerializeField] GameObject spawner;

    void Start()
    {
        if (levelFalse.Restart == 1 )
        {
            spawner.SetActive(true);
        }
    }

    
}

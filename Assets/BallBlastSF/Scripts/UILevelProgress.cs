using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevelProgress : MonoBehaviour
{
    [SerializeField] private Destroy destroy;

    [SerializeField] private Text currentLevel;
    

    public static int amountCoin;


    private void Start()
    {
        Load();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            amountCoin = 0;
        }
        

        currentLevel.text = "Монеты: " + amountCoin.ToString();
        Save();
    }
    
    private void Save()
    {
        PlayerPrefs.SetInt("amountCoin", amountCoin);
    }

    private void Load()
    {
        amountCoin = PlayerPrefs.GetInt("amountCoin", 0);
    }
    
}

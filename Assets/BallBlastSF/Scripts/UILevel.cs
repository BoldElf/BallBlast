using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    [SerializeField] Level level;

    [SerializeField] private Text currentLevel;
    [SerializeField] private Text nextLevel;
    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private Stone stone;

    [SerializeField] private Image progressBar;

    static public float size2;
    static public float size3;
    static public float size4;



    static public bool test = false;
    static public bool test1 = false;

    private float fillAmountStep;

    private void Start()
    {
        currentLevel.text = level.CurrentLevel.ToString();
        nextLevel.text = (level.CurrentLevel + 1).ToString();
        
        //fillAmountStep = 1f / 4f ;
        //fillAmountStep = 1f / (stoneSpawner.Amount * 14 + stoneSpawner.Amount);
        
    }
    
    private void Update()
    {
        //fillAmountStep = 1f / (stoneSpawner.Amount * 14f + stoneSpawner.Amount);

        if (test == true)
        {
            test = false;
            Bar();
        }
        
    }
    
    private void Bar()
    {
        //fillAmountStep = 1f / (stoneSpawner.Amount * 15f + (stoneSpawner.Amount * stoneSpawner.Amount));
        fillAmountStep = 1f / (stoneSpawner.GetAmount() * 15f);
        progressBar.fillAmount += fillAmountStep;
    } 
}

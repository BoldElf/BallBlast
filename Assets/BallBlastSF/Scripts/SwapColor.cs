using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwapColor : MonoBehaviour
{
    [SerializeField] SpriteRenderer stone;
   

    Color[] colorStone = new Color[5] { Color.black, Color.red, Color.cyan, Color.magenta, Color.green};

    public void Swap()
    {
        int index = Random.Range(0, colorStone.Length);
        stone.color = colorStone[index];
    }
    
}

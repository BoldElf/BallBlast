using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContinue : MonoBehaviour
{
    [SerializeField] StoneSpawner stoneSpawner;

    public void AddAmountStone()
    {
        stoneSpawner.AddAmount();
    }
}

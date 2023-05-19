using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    private int amountCoin;

   // public int AmountKeys => amountCoin;
    public int AmountCoin => amountCoin;

    private void AddCoin()
    {
        amountCoin += 1;
    }

    public int GetCoin()
    {
        return amountCoin;
    }
}

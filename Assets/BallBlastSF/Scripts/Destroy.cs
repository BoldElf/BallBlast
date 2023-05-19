using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroy : MonoBehaviour
{
    private int amountCoin;

    [HideInInspector] UILevelProgress uILevelProgress;


    public int AmountCoin => amountCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>();

        if(cart != null)
        {
            UILevelProgress.amountCoin += 1;

            Destroy(gameObject);
            
        }
    }
}

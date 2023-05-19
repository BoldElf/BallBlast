using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] GameObject shopPoint;
    [SerializeField] GameObject shop;

    private void Update()
    {
        Controling();
    }

    public void Controling()
    {
        if(shop.activeSelf == true)
        {
            shopPoint.SetActive(false);
        }
    }

}

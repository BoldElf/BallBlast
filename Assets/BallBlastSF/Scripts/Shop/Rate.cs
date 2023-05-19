using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rate : MonoBehaviour
{
    [SerializeField] Turret turret;

   
    public void AddRate()
    {
        /*
        if(UILevelProgress.amountCoin == 5)
        {
            turret.fireRate -= 0.1f;

            if(turret.fireRate < 0.1)
            {
                turret.fireRate = 0.1f;
            }

            UILevelProgress.amountCoin -= 5;
        } 
        */
        turret.RatePlus();
    }

}

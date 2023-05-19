using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] Turret turret;

    public void AddDamage()
    {
        turret.DamagePlus();
    }
}

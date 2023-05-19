using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAmount : MonoBehaviour
{
    [SerializeField] Turret turret;

    public void AddProjectileAmount()
    {
        turret.ProjectileAmountPlus();
    }
}

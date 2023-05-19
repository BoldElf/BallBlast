using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Destructible : MonoBehaviour
{
    public int maxHitPoints;
    
    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent ChangeHitPoints;

    
    private int hitPoints;
    private bool isDie = false;

    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHitPoints.Invoke();
    }

    public void ApllyDamage(int damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();

        if(hitPoints <= 0)
        {
            kill();
        }
    }

    public void AddHitPoints()
    {
        hitPoints += 50;
        if(hitPoints > 100)
        {
            hitPoints = 100;
        }
        ChangeHitPoints.Invoke();
    }

    public void kill()
    {
        if (isDie == true) return;
        hitPoints = 0;
        isDie = true;
        ChangeHitPoints.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}

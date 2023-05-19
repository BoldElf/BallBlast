using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Destructible))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private Text hitPointText;

    private Destructible destructible;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChangeHitPoints.AddListener(OnChangeHitPoints);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
    }

    private void OnChangeHitPoints()
    {
        int hitPoint = destructible.GetHitPoints();

        if(hitPoint >= 1000)
        {
            hitPointText.text = hitPoint / 1000 + "K";
        }
        else
        {
            if (hitPoint == 0)
            {
                hitPointText.text = (hitPoint + 1).ToString();
            }
            else
            {
                hitPointText.text = hitPoint.ToString();
            }
            
        }
        
    }


}

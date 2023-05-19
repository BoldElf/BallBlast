using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRestartUI : MonoBehaviour
{
    [SerializeField] GameObject restart;
    [SerializeField] GameObject start;
    [SerializeField] GameObject defeat;
    [SerializeField] GameObject victory;

    private void Update()
    {
        Controling();
    }

    public void Controling()
    {
        if (start.activeSelf == false)
        {
            restart.SetActive(true);
        }
        if(defeat.activeSelf == true)
        {
            restart.SetActive(false);
        }
        if (victory.activeSelf == true)
        {
            restart.SetActive(false);
        }
    }
}

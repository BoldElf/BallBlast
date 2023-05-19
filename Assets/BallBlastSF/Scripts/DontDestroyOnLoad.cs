using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private GameObject potion;

    void Start()
    {
        DontDestroyOnLoad(potion);
    }
}

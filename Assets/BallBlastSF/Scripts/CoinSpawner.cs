using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [HideInInspector] public GameObject coin;
    [SerializeField] Stone stone;


    private void Awake()
    {
        stone.AddCoin.AddListener(spawnCoin);
    }
    private void OnDestroy()
    {
        stone.AddCoin.RemoveListener(spawnCoin);
    }

    public void spawnCoin()
    {
        int number = Random.Range(0, 5);
        
        if (number == 1 || number == 5)
        {
            coin = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
         

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovment : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] CoinSpawner coinSpawner;

    private void Update()
    {
        coin.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                enabled = false;
            }
        }
    }
}
        

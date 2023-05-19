using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMovment : MonoBehaviour
{
    [SerializeField] GameObject potion;
    //[SerializeField] CoinSpawner coinSpawner;

    private void Update()
    {
        potion.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
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

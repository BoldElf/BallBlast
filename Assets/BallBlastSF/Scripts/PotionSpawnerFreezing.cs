using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnerFreezing : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [HideInInspector] private GameObject potion;
    [SerializeField] Stone stone;


    private void Awake()
    {
        stone.AddPotionFreezing.AddListener(spawnPotionFreezing);
    }
    private void OnDestroy()
    {
        stone.AddPotionFreezing.RemoveListener(spawnPotionFreezing);
    }

    public void spawnPotionFreezing()
    {
        int number = Random.Range(0,30);

        if(number == 5)
        {
            potion = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

}

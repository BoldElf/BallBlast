using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnerProtect : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [HideInInspector] private GameObject protect;
    [SerializeField] Stone stone;


    private void Awake()
    {
        stone.AddPotionProtect.AddListener(spawnPotionProtect);
    }
    private void OnDestroy()
    {
        stone.AddPotionProtect.RemoveListener(spawnPotionProtect);
    }

    public void spawnPotionProtect()
    {
        int number = Random.Range(0, 20);
        
        if (number == 10)
        {
            protect = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        
  
    }
}

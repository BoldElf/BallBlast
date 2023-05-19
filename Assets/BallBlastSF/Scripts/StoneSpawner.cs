using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [SerializeField] SwapColor swapColor;
    

    [Header("Balance")]
    [SerializeField] Turret turret;
    [SerializeField] private int amount;
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    [SerializeField] Level level;
    public float Amount => amount;

    [Space(10)] public UnityEvent Completed;

    private float timer;
    private float amountSpawned;
    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;

    private void Start()
    {
        Load();

        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));
        stoneMaxHitpoints = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoints = (int)(damagePerSecond * minHitpointsPercentage);

        timer = spawnRate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            spawn();
            timer = 0;
        }

        if(amountSpawned == amount)
        {
            enabled = false;
            Completed.Invoke();
        }
    }

    static private float cnt = 0f; // счетчик для того, что бы номера не сливались.

    private void spawn()
    {
        cnt += 0.02f;
        //Stone stone = Instantiate(stonePefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        int index = Random.Range(0, spawnPoints.Length);

        Stone stone = Instantiate(stonePefab, new Vector3(spawnPoints[index].position.x, spawnPoints[index].position.y, cnt), Quaternion.identity);

        //stone.SetSize((Stone.Size)Random.Range(1, 4));
        stone.SetSize((Stone.Size)3);
        stone.maxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);

        swapColor.Swap();

        amountSpawned++;  
    }

    public void AddAmount()
    {
        amount += 1;
        Save();
        level.AddLevel();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("amount", amount);
    }

    private void Load()
    {
        amount = PlayerPrefs.GetInt("amount", 1);
    }

    public int GetAmount()
    {
        return amount;
    }
}

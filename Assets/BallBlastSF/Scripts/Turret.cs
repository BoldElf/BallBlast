using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPosition;
    //[SerializeField] public float fireRate;
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField] private float projectileInterval;
    [SerializeField] private int projectileAmount;

    private float timer;
    public int Damage => damage;
    public int ProjectileAmount => projectileAmount;
    public float FireRate => fireRate;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            projectileAmount = 1;
        }
        Save();
    }

    private void SpawnProjectile()
    {
        float startPosX = shootPosition.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for(int i = 0; i < projectileAmount;i++)
        {
           Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval,shootPosition.position.y, shootPosition.position.z), 
                transform.rotation);
            projectile.SetDamage(damage);
        }

        
    }

    public void Fire()
    {
        if(timer >= fireRate)
        {
            SpawnProjectile();
            timer = 0;
        }
    }

    public void RatePlus()
    {
        if (UILevelProgress.amountCoin >= 5)
        {
            fireRate -= 0.1f;

            if (fireRate < 0.1)
            {
                fireRate = 0.1f;
            }

            UILevelProgress.amountCoin -= 5;
        }
    }

    public void DamagePlus()
    {
        if (UILevelProgress.amountCoin >= 5)
        {
            damage += 1;
            UILevelProgress.amountCoin -= 5;
        }
    }

    public void ProjectileAmountPlus()
    {
        
        if (UILevelProgress.amountCoin >= 5)
        {
            projectileAmount += 1;
            UILevelProgress.amountCoin -= 5;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("fireRate",fireRate);
        PlayerPrefs.SetInt("damage",damage);
        PlayerPrefs.SetInt("projectileAmount", projectileAmount);
    }

    private void Load()
    {
        fireRate = PlayerPrefs.GetFloat("fireRate",0.6f);
        damage = PlayerPrefs.GetInt("damage", 1);
        projectileAmount = PlayerPrefs.GetInt("projectileAmount", 1);
    }
}

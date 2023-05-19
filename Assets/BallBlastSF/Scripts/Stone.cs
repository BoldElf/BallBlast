using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }

    [SerializeField] private Size size;
    [SerializeField] private float spawnUpForce;
    [SerializeField] private CoinSpawner coinSpawner;
    
    private StoneMovement movment;

    [HideInInspector] public UnityEvent AddCoin;
    [HideInInspector] public UnityEvent AddPotionFreezing;
    [HideInInspector] public UnityEvent AddPotionProtect;


    private void Awake()
    {
        movment = GetComponent<StoneMovement>();
        Die.AddListener(OnStoneDesrtroyed);
        SetSize(size);
    }

    private void OnDestroy()
    {
        Die.RemoveListener(OnStoneDesrtroyed);
    }

    private void OnStoneDesrtroyed()
    {
        if(size != Size.Small)
        {
            SpawnStones();
            
        }
        UILevel.test = true;
        AddCoin.Invoke();
        AddPotionFreezing.Invoke();
        AddPotionProtect.Invoke();

        Destroy(gameObject);

    }

    static private float cnt1 = 0f; // счетчик для того, что бы номера не сливались.

    private void SpawnStones()
    {
        for(int i = 0; i < 2; i++)
        {
            cnt1 += 0.002f;

            //Stone stone = Instantiate(this, transform.position, Quaternion.identity);
            Stone stone = Instantiate(this, new Vector3(transform.position.x, transform.position.y, cnt1), Quaternion.identity);
            stone.SetSize(size - 1);
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            stone.movment.AddVerticalVelocity(spawnUpForce);
            stone.movment.SetHorizontalDirection((i % 2 * 2) -1);
        }
    }


    public void SetSize(Size size)
    {
        if (size < 0) return;
        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }

    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Huge) return new Vector3(1, 1, 1);
        if (size == Size.Big) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Normal) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return new Vector3(0.4f, 0.4f, 0.4f);

        return Vector3.one;
    }
}

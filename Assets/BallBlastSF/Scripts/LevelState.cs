using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] Cart cart;
    [SerializeField] StoneSpawner stoneSpawner;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed = false;
    private int cnt1;

    private void Awake()
    {
        stoneSpawner.Completed.AddListener(SpawnCollected);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }

    private void Start()
    {
        cnt1 = 0;
    }

    private void OnDestroy()
    {
        stoneSpawner.Completed.RemoveListener(SpawnCollected);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
    }

    private void SpawnCollected()
    {
        checkPassed = true;
    }

    private void Update()
    {
        if(cnt1 == 0)
        {
            timer += Time.deltaTime;

            if(timer > 0.5f)
            {
                if(checkPassed == true)
                {
                    if(FindObjectsOfType<Stone>().Length == 0)
                    {
                        Passed.Invoke();
                        cnt1 = 1;
                    }
                }
                timer = 0;
            }
        }
        
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pillar;
    [SerializeField] private float _spawnTime = 2f;

    

    private void Start()
    {
       // player.onDead += StopSpawing;

        GameManagerFB.StopSpawn += StopSpawing;

        GameManagerFB.StartSpawn += StarSpawning;
    }
    
    void Spawn()
    {   
 
      Instantiate(_pillar, new Vector2(transform.position.x,UnityEngine.Random.Range(-5.9f,6.9f)), Quaternion.identity);
        
    }

    void StarSpawning()
    {
        InvokeRepeating("Spawn", 1, _spawnTime);
    }

    
    void StopSpawing()
    {
        CancelInvoke("Spawn");
    }
    


}

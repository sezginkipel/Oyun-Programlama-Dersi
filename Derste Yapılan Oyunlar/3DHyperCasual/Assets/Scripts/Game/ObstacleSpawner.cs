using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    
    public GameObject obstaclePrefab;
 
    void Start()
    {
        
        StartCoroutine(spawnObstacle());
        
    }

    IEnumerator spawnObstacle()
    {
        while (1 == 1)
        {
            float randomX = Random.Range(-2.5f, 2.5f);
            float randomY = Random.Range(-0.5f, 1.5f);
            float randomZ = Random.Range(-30, 50);
            Instantiate(obstaclePrefab, new Vector3(randomX, randomY, randomZ), obstaclePrefab.transform.rotation);
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}

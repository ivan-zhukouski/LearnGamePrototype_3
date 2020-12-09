using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(10, -9, -6);
    public bool isStopSpawn = false;

    private float startDelay = 3f;
    private float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnObstacle();
        
    }
    void SpawnObstacle()
    {
        
        if(isStopSpawn == false)
        {
          repeatRate = Random.Range(2f,4f);
          int prefabIndex = Random.Range(0, obstaclePrefab.Length);
          Instantiate(obstaclePrefab[prefabIndex], spawnPos, obstaclePrefab[prefabIndex].transform.rotation);
        }
        Invoke("SpawnObstacle", repeatRate);
        
    }

}

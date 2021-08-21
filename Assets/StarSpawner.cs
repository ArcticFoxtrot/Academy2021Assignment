using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    [Header("Star Spawner Settings")]
    [SerializeField] float spawnThreshold = 5f;
    

    [Header("References To Other Gameobjects")]
    [SerializeField] GameObject starPrefab;
    [SerializeField] Transform StarParent;
    [SerializeField] ObstacleSpawner obstacleSpawner;


    private Vector3 lastSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        //if enough distance has been travelled, spawn a new obstacle
        if(Vector3.Distance(lastSpawnPoint, transform.position) > spawnThreshold){
            InstantiateStar();
        }
    }

    private void InstantiateStar()
    {
        Vector3 lastObstaclePoint = obstacleSpawner.GetLastSpawnPoint();
        GameObject latestStar = Instantiate(starPrefab, lastObstaclePoint, Quaternion.identity, StarParent.transform);
        lastSpawnPoint = latestStar.transform.position;
    }
}

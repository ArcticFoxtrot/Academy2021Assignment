using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcherSpawner : MonoBehaviour
{

    [Header("Color Switcher Settings")]
    [SerializeField] float spawnThreshold = 5f;
    [SerializeField] float spawnOffsetFromObstacle = 3f;


    [Header("References To Other Gameobjects")]
    [SerializeField] GameObject switcherPrefab;
    [SerializeField] GameObject switcherParent;
    [SerializeField] ObstacleSpawner obstacleSpawner;

    //latest spawn point
    private Vector3 lastSpawnPoint;
    private Vector3 lastObstaclePoint;

    // Update is called once per frame
    void Update()
    {
        //if enough distance has been travelled, spawn a new obstacle
        if(Vector3.Distance(lastSpawnPoint, transform.position) > spawnThreshold){
            InstantiateSwitcher();
        }
    }

    private void InstantiateSwitcher()
    {
        lastObstaclePoint = obstacleSpawner.GetLastSpawnPoint();
        Vector3 spawnPoint = new Vector3(lastObstaclePoint.x, lastObstaclePoint.y + spawnOffsetFromObstacle, lastObstaclePoint.z);
        GameObject latestSwitcher = Instantiate(switcherPrefab, spawnPoint, Quaternion.identity, switcherParent.transform);
        lastSpawnPoint = latestSwitcher.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [Header("Obstacle Spawner Settings")]
    [SerializeField] float spawnThreshold = 5f;
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();

    [Header("References To Other Gameobjects")]
    [SerializeField] Transform obstacleParent;


    private Vector3 lastSpawnPoint;
    private GameObject latestObstacle;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        //if enough distance has been travelled, spawn a new obstacle
        if(Vector3.Distance(lastSpawnPoint, transform.position) > spawnThreshold){
            InstantiateObstacle();
        }
    }

    public void InstantiateObstacle(){
        //instantiate random obstacle
        latestObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)], transform.position, Quaternion.identity, obstacleParent);
        ObstacleRotator obstacleRotator = latestObstacle.GetComponent<ObstacleRotator>();
        lastSpawnPoint = latestObstacle.transform.position;
    }

    public Vector3 GetLastSpawnPoint(){
        return lastSpawnPoint;
    }

}

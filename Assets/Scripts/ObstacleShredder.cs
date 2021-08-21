using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShredder : MonoBehaviour
{

    [Header("Shredder settings")]
    [SerializeField] float shredderOffset = 10f;
    [SerializeField] LayerMask obstacleLayerMask;

    private BoxCollider2D boxCollider;
    private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        if(!boxCollider || boxCollider == null){
            Debug.LogWarning("Shredder can not find a shredder collider!");
        }

        mainCamera = Camera.main;
        if(!mainCamera || mainCamera == null){
            Debug.LogWarning("Shredder can not find a main camera!");
        }
    }

    private void Update() {
        FollowCamera();
        GetShreddableObjects();
    }

    private void GetShreddableObjects()
    {
        //get all obstacles inside shredder box
        Collider2D[] colliders = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale / 2, 0, obstacleLayerMask);
        ObstaclePart obstaclePart;
        foreach(Collider2D c in colliders){
            //Destroy obstacle parent object
            if(c.gameObject.TryGetComponent<ObstaclePart>(out obstaclePart)){
                obstaclePart.DestroyObstacle();
            } else {
                Destroy(c.gameObject);
            }
        }
    }

    private void FollowCamera(){
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - shredderOffset, 0);
    }

}

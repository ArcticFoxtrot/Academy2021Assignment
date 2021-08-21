using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Camera Movement Settings")]
    [SerializeField] float cameraYThreshold;
    [SerializeField] float cameraMoveSpeed = 5f;
    [SerializeField] float smoothTime = .3f;

    [Header("Reference To Player components")]
    [SerializeField] PlayerController playerController;

    private Vector3 currentPosition;
    private Vector3 nextPosition;
    private float cameraZPosition;
    private Vector3 velocity = Vector3.zero;
    private bool isGameOver = false;


    private void OnEnable() {
        //subscribe to PlayerIsDead
        PlayerDeathHandler.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable() {
        PlayerDeathHandler.OnPlayerDeath -= HandlePlayerDeath;
    }

    void Start()
    {
        cameraZPosition = this.transform.position.z;
    }

    private void LateUpdate() {
        if(!isGameOver){
            currentPosition = transform.position;
            nextPosition = playerController.transform.position;
            nextPosition.z = cameraZPosition;
            //compare current position to player position, if current position + threshold is lower than player position, move upwards
            if(currentPosition.y + cameraYThreshold <= nextPosition.y){
                //move camera upwards
                transform.position = Vector3.SmoothDamp(transform.position, nextPosition, ref velocity, smoothTime);
            }
        }
    
        
        
    }

    private void HandlePlayerDeath()
    {
        isGameOver = true;
    }
}

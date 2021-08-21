using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement Settings")]
    [SerializeField] float upForce = 1f;
    [SerializeField] float maxVelocity = 5f;
    [SerializeField] AudioClip jumpAudio;
    [SerializeField] AudioSource playerAudioSource;
    

    [Header("Required components")]
    [SerializeField] Rigidbody2D rb2d;

    private bool shouldJump;
    private bool isGameStarted = false;

    private void OnEnable() {
        GameStartHandler.OnGameStarted += HandleGameStarted;
    }

    private void OnDisable() {
        GameStartHandler.OnGameStarted -= HandleGameStarted;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStarted){
            GetInput();
        }
    }

    private void FixedUpdate() {
        if(shouldJump){
            rb2d.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);
            shouldJump = false;
        }
    }

    private void GetInput(){
        if(Input.GetMouseButtonDown(0)){
            shouldJump = true; //set to prevent frame mismatches between update and fixedupdate
            playerAudioSource.PlayOneShot(jumpAudio);
        }
    }

    private void HandleGameStarted(){
        isGameStarted = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerHandler : MonoBehaviour
{
    
    //This component only checks the bottom collision and triggers player death if player hits the collider
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerDeathHandler>().HandlePlayerDeath();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    [Header("Player Death FX")]
    [SerializeField] GameObject deathParticles;
    [SerializeField] AudioClip deathAudio;

    [Header("References To Other Gameobjects")]
    [SerializeField] GameObject deathObjectParent;
    [SerializeField] AudioSource audioSource;



    public void HandlePlayerDeath(){
        //Instantiate death particles
        Instantiate(deathParticles, transform.position, Quaternion.identity, deathObjectParent.transform);
        audioSource.PlayOneShot(deathAudio);
        //send an event that player is dead
        if(OnPlayerDeath != null){
            OnPlayerDeath();
        }
        Destroy(gameObject);
    }
}

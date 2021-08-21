using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{

    [Header("ColorSwitcher destroy settings")]
    [SerializeField] ParticleSystem destroyParticles;

    //private
    private Collider2D coll;
    private PlayerMaterialHandler playerMaterialHandler;

    

    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<Collider2D>();
        if(!coll || coll == null){
            Debug.LogWarning("Color Switcher could not find a collider for itself");
        } else {
            coll.isTrigger = true;
        }

        playerMaterialHandler = FindObjectOfType<PlayerMaterialHandler>();
        if(!playerMaterialHandler || playerMaterialHandler == null){
            Debug.LogWarning("Color Switcher could not find a player material handler");
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Color Switcher hit!");
        if(other.CompareTag("Player")){
            playerMaterialHandler.SetNewPlayerMaterial();
            Material destroyFXMaterial = playerMaterialHandler.GetPlayerMaterial();
            SelfDestruct(destroyFXMaterial);
        }
        
    }

    private void SelfDestruct(Material fxMaterial){
        ParticleSystem spawnedFX = Instantiate(destroyParticles, transform.position, Quaternion.identity);
        AudioSource spawnedFXAudio = spawnedFX.gameObject.GetComponent<AudioSource>();
        spawnedFXAudio.Play();
        var main = spawnedFX.main;
        main.startColor = fxMaterial.color;
        spawnedFX.Play();
        Destroy(gameObject);
    }
}

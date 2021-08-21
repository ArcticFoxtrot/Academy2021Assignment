using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialHandler : MonoBehaviour
{

    [Header("Player Color Settings")]
    [SerializeField] Material initialMaterial;
    [SerializeField] List<Material> possibleMaterials = new List<Material>();

    [Header("Required Components")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerDeathHandler playerDeathHandler;
    
    
    private Material playerMaterial;

    // Start is called before the first frame update
    void Start()
    {
        playerMaterial = initialMaterial;
        spriteRenderer.material = playerMaterial;
    }

    public Material GetPlayerMaterial(){
        return playerMaterial;
    }

    public void SetNewPlayerMaterial()
    {
        //set a new material which is not the current material
        List<Material> materials = new List<Material>();
        foreach (Material m in possibleMaterials){
            if(m != playerMaterial)
            materials.Add(m);
        }
        int newIndex = UnityEngine.Random.Range(0, 3);
        playerMaterial = materials[newIndex];
        spriteRenderer.material = playerMaterial;


    }

    public void PlayerDeath(){
        playerDeathHandler.HandlePlayerDeath();
    }

}

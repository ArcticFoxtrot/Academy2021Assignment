using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePart : MonoBehaviour
{

    [Header("Obstacle Settings")]
    [SerializeField] Material obstacleMaterial;

    [Header("Required Components")]
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.material = obstacleMaterial;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerMaterialHandler playerMaterialHandler;
        if(other.TryGetComponent<PlayerMaterialHandler>(out playerMaterialHandler)){
            if(playerMaterialHandler.GetPlayerMaterial() != obstacleMaterial){
                //Debug.Log("Player hit wrong color, game over!");
                playerMaterialHandler.PlayerDeath();
            }
        }
    }

    public void DestroyObstacle(){
        //for shredding purposes, called from Shredder
        if(transform.parent.gameObject.GetComponentInParent<ObstacleRotator>()){
            Destroy(transform.parent.gameObject.GetComponentInParent<ObstacleRotator>().gameObject);
        } else {
            Destroy(transform.parent.gameObject);
        }
        
    }

}

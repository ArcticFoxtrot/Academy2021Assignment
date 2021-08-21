using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement Settings")]
    [SerializeField] float upForce = 1f;
    [SerializeField] float maxVelocity = 5f;
    

    [Header("Required components")]
    [SerializeField] Rigidbody2D rb2d;

    private bool shouldJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
            shouldJump = true;
        }
    }
}

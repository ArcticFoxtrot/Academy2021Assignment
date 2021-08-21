using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    
    [Header("Rotation Settings")]
    [SerializeField] Transform rotatorPivotPoint;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] bool rotateClockWise = true;

    public ObstacleRotator[] obstacleRotators;
    public bool isParent = true;
    private float rotationDir;
    private int parentCount;
    public ObstacleRotator[] parentRotators;

    private void Start() {
        obstacleRotators = GetComponentsInChildren<ObstacleRotator>();
        parentRotators = GetComponentsInParent<ObstacleRotator>();

        //getcomponents always returns self as one, therefore subtract
        parentCount = parentRotators.Length - 1;

        //if has children, and has no parent, is parent
        if(parentCount >= 1){
            isParent = false;
        }

        //if this is a parent rotator, set the rotation direction randomly
        //isParent = obstacleRotators.Length > 1;
        if(isParent){
            rotateClockWise = GetRandomBool();
            if(rotateClockWise == false){
            rotationSpeed = -rotationSpeed;
            }
        }

        rotationDir = rotationSpeed / Mathf.Abs(rotationSpeed); //get direction as 1 or -1

        //if there are children for the rotator, set their rotation to match
        if(isParent){
            foreach (ObstacleRotator rotator in obstacleRotators){
                if(rotator.gameObject != this.gameObject){
                    rotator.SetRotationDirection(rotationDir);
                }
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotatorPivotPoint.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }
/*
    public void SetRotationDirection(bool t){
        if(rotateClockWise != t){
            rotateClockWise = t;
            if(rotateClockWise == false){
                rotationSpeed = -rotationSpeed;
            }
        }

    }
*/

    public void SetRotationDirection(float dir){
        //dir should be either 1 or -1
        rotationSpeed = rotationSpeed * dir;
    }

    private bool GetRandomBool(){
        return Random.Range(0,2) == 1;
    }

}

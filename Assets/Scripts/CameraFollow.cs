using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    [SerializeField] private Transform followTransform;

    private Vector3 offsetPosition;
    

    private void Start() {
        
    }

    private void Update() {
        HandlePosition();
    }

    private void HandlePosition() {
        float tempPosZ = followTransform.position.z - 6f; 
        offsetPosition = new(2.6f, 4.85f, tempPosZ);
        transform.position = offsetPosition;

    }
    private void HandleRotation() {

    }

}

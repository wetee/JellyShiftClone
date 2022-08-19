using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundMovement : MonoBehaviour{

    public float groundSpeedModifier;

    private void Update() {
        GroundMovement();
    }

    private void GroundMovement() {
        Vector3 groundInput = groundSpeedModifier * Time.deltaTime * Vector3.back;

        transform.position += groundInput;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehavior : MonoBehaviour{

    [SerializeField] private Transform Bean;
    [SerializeField] private Transform ghost;

    private float posX;
    private float posY;
    private float posZ;
    private float scaleZ;

    private void Start() {
        posX = 0f;
    }

    private void Update() {
        posY = Bean.position.y;
        posZ = (ghost.position.z + Bean.position.z) / 2f;
        scaleZ = ghost.position.z - Bean.position.z;
        HandlePosition();
        HandleScale();
    }

    private void HandlePosition() {
        Vector3 tempPosition = new Vector3(posX, posY, posZ);
        transform.position = tempPosition;
    }

    private void HandleScale() {
        Vector3 scaleOffset = new Vector3(0f, 0f, scaleZ);
        transform.localScale = Bean.transform.localScale + scaleOffset;
    }


}

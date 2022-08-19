using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour {

    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform bridgeTransform;
    [SerializeField] private Transform[] obstacleTransforms;

    [HideInInspector] public int index = 0;

    
    private void Update() {    
        HandleScaling();
        HandlePosition();
    }

    private void HandlePosition() {
        if (index >= obstacleTransforms.Length) {
            bridgeTransform.gameObject.SetActive(false);
            gameObject.SetActive(false);
            return;
        }
        Vector3 tempPosition = new(0f, parentTransform.position.y, obstacleTransforms[index].position.z);
        transform.position = tempPosition;
    }

    private void HandleScaling() {
        Vector3 scaleOffset = new Vector3(0f,0f, -0.25f);
        transform.localScale = parentTransform.localScale + scaleOffset;
    }

    


}

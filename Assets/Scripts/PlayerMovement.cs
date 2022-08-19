using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Camera mainCamera;
    private Rigidbody rb;
    

    [SerializeField] private GhostBehavior ghostBehavior;
    [SerializeField] private PlaygroundMovement playgroundMovement;
    [SerializeField] private LayerMask groundLayerMask;


    private readonly float upperBound = 4f;
    private readonly float lowerBound = 1f;

    private bool isCollided = false;
    private bool isGrounded;


    private void Awake() {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (isCollided) {
            rb.AddForce(Vector3.back * 7f, ForceMode.Impulse);
            isCollided = false;
        }
        GroundCheck();
        Debug.Log(isGrounded);
    }

    private void FixedUpdate() {
        if (Input.GetButton("Fire1") && isGrounded) HandleShapeChange();

    }

    private void HandleShapeChange() {

        if (!isGrounded) return;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;

        Vector3 scaleVector = mainCamera.ScreenToWorldPoint(mousePosition);

        scaleVector.z = transform.localScale.z;
        scaleVector.y *= 2f;
        scaleVector.y = Mathf.Clamp(scaleVector.y, lowerBound, upperBound);

        float currentScaleX = upperBound / scaleVector.y;

        scaleVector.x = Mathf.Clamp(currentScaleX, lowerBound, upperBound);

        transform.localScale = scaleVector;

        Vector3 newCenterOfMass = new Vector3(transform.position.x, scaleVector.y / 2f, transform.position.z);
        transform.position = newCenterOfMass;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("ObstaclePiece")) {
            Destroy(collision.gameObject);
            isCollided = true;
        }
        //else if (collision.gameObject.tag.Equals("Playground")) {
        //    isGrounded = true;
        //}
        //else {
        //    isGrounded = false;
        //}
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Obstacle")) {
            ghostBehavior.index++;
        }
        else if (other.gameObject.tag.Equals("FinishLine")) {
            playgroundMovement.groundSpeedModifier = 0f;
        }
        else if (other.gameObject.tag.Equals("ForceApplier")) {
            rb.AddForce(new Vector3(0f, 5f, 0f),ForceMode.Impulse);
        }
    }

    private void GroundCheck() {
        Vector3 tempPosition = new Vector3(0f, 0f, 2.25f);
        Vector3 tempScale = new Vector3(transform.localScale.x, 0.02f, transform.localScale.z);
        isGrounded = Physics.CheckBox(tempPosition, tempScale / 2f, Quaternion.identity, groundLayerMask);
        
    }


}

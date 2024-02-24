using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretPlayerMovement : MonoBehaviour
{
   public float secretMoveSpeed;
   public float groundDrag;
   public Transform secretOrientation;
   float secretHorizontalInput;
   float secretVerticalInput;
   Vector3 secretMoveDirection;
   Rigidbody secretRb;
   private void Start(){
    secretRb = GetComponent<Rigidbody>();
    secretRb.freezeRotation = true;
   }
   private void Update(){
    SecretInputFunction();
    secretRb.drag = groundDrag;
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(1);
    }
   }
   private void FixedUpdate() {
    SecretPlayerMovementFunction();
   }
   private void SecretInputFunction(){
    secretHorizontalInput = Input.GetAxisRaw("Horizontal");
    secretVerticalInput = Input.GetAxisRaw("Vertical");
   }
   private void SecretPlayerMovementFunction(){
    secretMoveDirection = secretOrientation.forward * secretVerticalInput + secretOrientation.right * secretHorizontalInput;
    secretRb.AddForce(secretMoveDirection.normalized * secretMoveSpeed * 10f);
   }

}

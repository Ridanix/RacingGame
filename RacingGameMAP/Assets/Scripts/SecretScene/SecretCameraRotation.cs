using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SecretCameraRotation : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    public Transform playerOrientation;
    float xCameraRotation;
    float yCameraRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;
        yCameraRotation += mouseX;
        xCameraRotation -= mouseY;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xCameraRotation, yCameraRotation, 0);
        playerOrientation.rotation = Quaternion.Euler(0f, yCameraRotation, 0);
    }
}


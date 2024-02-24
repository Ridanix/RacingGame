using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCameraHolderScript : MonoBehaviour
{
   
    public Transform cameraPositionTransform;
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPositionTransform.position;
    }
}

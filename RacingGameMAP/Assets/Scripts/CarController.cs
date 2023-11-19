using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody carRigidBody;
    public WheelColliders wheelColliders;
    public WheelMeshes wheelMeshes;
    public AnimationCurve steeringCurve;
    public float brakePower;
    public float brakeInput;
    public float slipAngle;
    public float gasInput;
    public float steeringInput;
    public float enginePower;
    private float speed;
    private void Start()
    {
        carRigidBody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        GetInputs();
        ApplyWheels(wheelColliders.LFWheel, wheelMeshes.LFWheel);
        ApplyWheels(wheelColliders.LRWheel, wheelMeshes.LRWheel);
        ApplyWheels(wheelColliders.RFWheel, wheelMeshes.RFWheel);
        ApplyWheels(wheelColliders.RRWheel, wheelMeshes.RRWheel);
        speed = carRigidBody.velocity.magnitude;
        wheelColliders.LRWheel.motorTorque = enginePower * gasInput;
        wheelColliders.RRWheel.motorTorque = enginePower * gasInput;
        wheelColliders.LFWheel.steerAngle = steeringAngle;
        wheelColliders.RFWheel.steerAngle = steeringAngle;
        wheelColliders.LFWheel.brakeTorque = brakePower * brakeInput * 0.75f;
        wheelColliders.RFWheel.brakeTorque = brakePower * brakeInput * 0.75f;
        wheelColliders.LRWheel.brakeTorque = brakePower * brakeInput * 0.35f;
        wheelColliders.RRWheel.brakeTorque = brakePower * brakeInput * 0.35f;
    }
    void GetInputs()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward, carRigidBody.velocity - transform.forward);
        if (slipAngle < 120f)
        {
            if (gasInput < 0)
            {
                brakeInput = Mathf.Abs(gasInput);
                gasInput = 0;
            }
            
            
        }
        else brakeInput = 0;
    }
    void ApplyWheels(WheelCollider colliderWheel, MeshRenderer meshWheel)
    {
        Quaternion quat;
        Vector3 position;
        colliderWheel.GetWorldPose(out position, out quat);
     //Quaternion quatNew = Quaternion.Euler(quat.eulerAngles.x, quat.eulerAngles.y, 90f);

        meshWheel.transform.position = position;
        meshWheel.transform.rotation = quat;
    }
}
[System.Serializable]
public class WheelColliders
{
    public WheelCollider LFWheel;
    public WheelCollider RFWheel;
    public WheelCollider LRWheel;
    public WheelCollider RRWheel;
}
[System.Serializable]
public class WheelMeshes
{
    public MeshRenderer LFWheel;
    public MeshRenderer RFWheel;
    public MeshRenderer LRWheel;
    public MeshRenderer RRWheel;
}


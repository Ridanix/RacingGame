using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarController : MonoBehaviour
{
    private Rigidbody carRigidBody;
    public WheelColliders wheelColliders;
    public WheelMeshes wheelMeshes;
    public AnimationCurve steeringCurve;
    public AnimationCurve hpToCurrentRPMCurve;
    public int currentGear;
    public int currentGearMax;
    public float brakePower;
    public float brakeInput;
    public float slipAngle;
    public float gasInput;
    public float steeringInput;
    public float enginePower;
    public float currentRPM;
    public float redLineRPM;
    public float idleRPM;
    public float[] gearRatios;
    public float carDifferentialRatio;
    private float speed;
    private float currentTorque;
    private float carClutch;
    private float wheelRPM;
    public TMP_Text currentGearText;
    public TMP_Text currentRPMText;
    private void Start()
    {
        carRigidBody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentGear > 0)
        {
            currentGear = currentGear - 1;
        }
        if (Input.GetKeyDown(KeyCode.E) && currentGear < currentGearMax)
        {
        
            currentGear = currentGear + 1;
        }
        if (currentRPM > redLineRPM) currentRPMText.color = Color.red;
        else currentRPMText.color = Color.white;


        currentGearText.text = (currentGear + 1).ToString();
        currentRPMText.text = currentRPM.ToString("0,000");
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        GetInputs();
        ApplyWheels(wheelColliders.LFWheel, wheelMeshes.LFWheel);
        ApplyWheels(wheelColliders.LRWheel, wheelMeshes.LRWheel);
        ApplyWheels(wheelColliders.RFWheel, wheelMeshes.RFWheel);
        ApplyWheels(wheelColliders.RRWheel, wheelMeshes.RRWheel);
        speed = carRigidBody.velocity.magnitude;

        currentTorque = CalculateTorque();
        wheelColliders.LRWheel.motorTorque = currentTorque * gasInput;
        wheelColliders.RRWheel.motorTorque = currentTorque * gasInput;


        wheelColliders.LFWheel.steerAngle = steeringAngle;
        wheelColliders.RFWheel.steerAngle = steeringAngle;
        wheelColliders.LFWheel.brakeTorque = brakePower * brakeInput * 0.75f;
        wheelColliders.RFWheel.brakeTorque = brakePower * brakeInput * 0.75f;
        wheelColliders.LRWheel.brakeTorque = brakePower * brakeInput * 0.35f;
        wheelColliders.RRWheel.brakeTorque = brakePower * brakeInput * 0.35f;
    }

    float CalculateTorque()
    {
        float torque = 0;

        if (carClutch < 0.1f)
        {
            currentRPM = Mathf.Lerp(currentRPM, Mathf.Max(idleRPM, redLineRPM * gasInput) + Random.Range(-50, 50), Time.deltaTime);
        }
        else
        {
            wheelRPM = Mathf.Abs((wheelColliders.RRWheel.rpm + wheelColliders.LRWheel.rpm) / 2f) * gearRatios[currentGear] * carDifferentialRatio;
            currentRPM = Mathf.Lerp(currentRPM, Mathf.Max(idleRPM - 600, wheelRPM), Time.deltaTime * 3f);
            torque = (hpToCurrentRPMCurve.Evaluate(currentRPM / redLineRPM) * enginePower / currentRPM) * gearRatios[currentGear] * carDifferentialRatio * 5252f * carClutch;
        }
        return torque;
    }

    void GetInputs()
    {
        carClutch = Input.GetKey(KeyCode.LeftShift) ? 0 : Mathf.Lerp(carClutch, 1, Time.deltaTime);
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


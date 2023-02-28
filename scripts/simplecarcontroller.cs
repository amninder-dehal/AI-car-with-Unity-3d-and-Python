// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
    
// public class simplecarcontroller : MonoBehaviour {
//     public List<AxleInfo> axleInfos; // the information about each individual axle
//     public float maxMotorTorque; // maximum torque the motor can apply to wheel
//     public float maxSteeringAngle; // maximum steer angle the wheel can have
        
//     public void FixedUpdate()
//     {
//         float motor = maxMotorTorque * Input.GetAxis("Vertical");
//         float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
//         foreach (AxleInfo axleInfo in axleInfos) {
//             if (axleInfo.steering) {
//                 axleInfo.leftWheel.steerAngle = steering;
//                 axleInfo.rightWheel.steerAngle = steering;
//             }
//             if (axleInfo.motor) {
//                 axleInfo.leftWheel.motorTorque = motor;
//                 axleInfo.rightWheel.motorTorque = motor;
//             }
//         }
//     }
// }
    
// [System.Serializable]
// public class AxleInfo {
//     public WheelCollider leftWheel;
//     public WheelCollider rightWheel;
//     public bool motor; // is this wheel attached to motor?
//     public bool steering; // does this wheel apply steer angle?
// }


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplecarcontroller : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot
;       wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
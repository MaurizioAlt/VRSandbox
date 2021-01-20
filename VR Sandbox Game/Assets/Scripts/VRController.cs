using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    public float sensitivity = 0.1f;
    public float speed = 0.0f;
    public float MaxSpeed = 2.0f;
    public float gravity = 30.0f;
    public float rotationAmount = 90;

    public SteamVR_Action_Boolean rotatePress;
    public SteamVR_Action_Boolean movePress;
    public SteamVR_Action_Vector2 moveValue;

    private CharacterController characterController;
    private Transform cameraRig;
    private Transform head;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        cameraRig = SteamVR_Render.Top().origin;
        head = SteamVR_Render.Top().head;
    }

    void Update()
    {
        HandleHeight();
        CalculateMovement();
        SnapRotation();
    }

    void HandleHeight()
    {
        // Get the head in local space
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        characterController.height = headHeight;

        // Cut in half and apply the skin width to the character controller
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        // Gets the center position of our head for the new center of the capusle collider in the x and z direction
        newCenter.x = head.localPosition.x;
        newCenter.z = head.localPosition.z;

        // Apply
        characterController.center = newCenter;
    }

    void CalculateMovement()
    {
        Vector3 orientationEuler = new Vector3(0, head.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (movePress.GetStateUp(inputSource))
            speed = 0;

        if (movePress.state)
        {
            // Accelerates and clamps the speed when we reach the desired max speed
            speed += moveValue.axis.magnitude * sensitivity;
            speed = Mathf.Clamp(speed, -MaxSpeed, MaxSpeed);

            // Orientation
            movement += orientation * (speed * Vector3.forward);
        }

        // Add gravity
        movement.y -= gravity * Time.deltaTime;

        characterController.Move(movement * Time.deltaTime);
    }
    void SnapRotation()
    {
        float snapValue = 0.0f;

        // when we press down on our left or right grip we will rotate
        if (rotatePress.GetStateDown(SteamVR_Input_Sources.LeftHand))
            snapValue = -Mathf.Abs(rotationAmount);

        if (rotatePress.GetStateDown(SteamVR_Input_Sources.RightHand))
            snapValue = Mathf.Abs(rotationAmount);

        transform.RotateAround(head.position, Vector3.up, snapValue);
    }
}

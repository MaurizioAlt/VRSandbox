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
    public SteamVR_Action_Boolean m_MovePress;
    public SteamVR_Action_Vector2 m_MoveValue;

    private CharacterController m_CharacterController = null;
    private Transform m_CameraRig;
    private Transform m_Head;


    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
    }

    void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateMovement();
        SnapRotation();
    }

    private void HandleHeight()
    {
        // Get the head in local space
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_CharacterController.height = headHeight;

        // Cut in half and apply the skin width to the character controller
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2;
        newCenter.y += m_CharacterController.skinWidth;

        // Gets the center position of our head for the new center of the capusle collider in the x and z direction
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        // Apply
        m_CharacterController.center = newCenter;
    }

    private void CalculateMovement()
    {
        Vector3 orientationEuler = new Vector3(0, m_Head.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (m_MovePress.GetStateUp(inputSource))
            speed = 0;

        if (m_MovePress.state)
        {
            // Accelerates and clamps the speed when we reach the desired max speed
            speed += m_MoveValue.axis.magnitude * sensitivity;
            speed = Mathf.Clamp(speed, -MaxSpeed, MaxSpeed);

            // Orientation
            movement += orientation * (speed * Vector3.forward)*Time.deltaTime;
        }

        // Add gravity
        movement.y -= gravity * Time.deltaTime;

        m_CharacterController.Move(movement);
    }
    private void SnapRotation()
    {
        float snapValue = 0.0f;

        // when we press down on our left or right grip we will rotate
        if (rotatePress.GetStateDown(SteamVR_Input_Sources.LeftHand))
            snapValue = -Mathf.Abs(rotationAmount);

        if (rotatePress.GetStateDown(SteamVR_Input_Sources.RightHand))
            snapValue = Mathf.Abs(rotationAmount);

        transform.RotateAround(m_Head.position, Vector3.up, snapValue);
    }
    
    private void HandleHead()
    {
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;

    }
}

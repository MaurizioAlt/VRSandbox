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
    public float rotationIncrement = 90;

    public SteamVR_Action_Boolean rotatePressLeft = null;
    public SteamVR_Action_Boolean rotatePressRight = null;
    public SteamVR_Action_Boolean fly = null;
    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private CharacterController m_CharacterController = null;
    private Transform m_CameraRig;
    private Transform m_Head;
    public float flySpeed = 1.0f;

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

        // Apply
        m_CharacterController.center = newCenter;
    }

    private void CalculateMovement()
    {
        Quaternion orientation = CalculateOrientation();
        Vector3 movement = Vector3.zero;
        Vector3 flyingMovement = Vector3.zero;

        if (m_MoveValue.axis.magnitude == 0)
            speed = 0;


            // Accelerates and clamps the speed when we reach the desired max speed
            speed += m_MoveValue.axis.magnitude * sensitivity;
            speed = Mathf.Clamp(speed, -MaxSpeed, MaxSpeed);

            // Orientation
            movement += orientation * (speed * Vector3.forward);

        if (fly.GetState(SteamVR_Input_Sources.RightHand)) {
            flyingMovement += flySpeed * Vector3.up;
           }
        else if (fly.GetState(SteamVR_Input_Sources.LeftHand))
        {
            flyingMovement += flySpeed * Vector3.down;
        }
        // Add gravity
        //movement.y -= gravity * Time.deltaTime;

        m_CharacterController.Move(flyingMovement * Time.deltaTime);
        m_CharacterController.Move(movement * Time.deltaTime);

    }

    private Quaternion CalculateOrientation()
    {
        float rotation = Mathf.Atan2(m_MoveValue.axis.x, m_MoveValue.axis.y);
        rotation *= Mathf.Rad2Deg;

        Vector3 orientationEuler = new Vector3(0, m_Head.eulerAngles.y+rotation, 0);
        return Quaternion.Euler(orientationEuler);
    }
    private void SnapRotation()
    {
        float snapValue = 0.0f;

        // when we press down on our left or right grip we will rotate
        if (rotatePressLeft.GetStateDown(SteamVR_Input_Sources.LeftHand))
            snapValue = -Mathf.Abs(rotationIncrement);

        if (rotatePressRight.GetStateDown(SteamVR_Input_Sources.LeftHand))
            snapValue = Mathf.Abs(rotationIncrement);

        transform.RotateAround(m_Head.position, Vector3.up, snapValue);
    }
    
   
}

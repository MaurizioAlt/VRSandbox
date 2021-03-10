using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotateObject : MonoBehaviour
{
    public SteamVR_Action_Boolean m_RotateAction = null;
    public SteamVR_Action_Vector2 m_rotateValue = null;

    private SteamVR_Behaviour_Pose m_Pose = null;

    private bool rotatingObj = false;
    public bool canRotate = false;

    // Start is called before th7e first frame update
    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_RotateAction.GetState(m_Pose.inputSource) && canRotate)
        {
            rotate();
        }
    }

    private void rotate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector2 delta;

        float rotateSpeed = 1f;
        Vector3 rotationToMake = new Vector3(0, 0, 0);


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("InteractableObject"))
            {
                rotationToMake.x += -(m_rotateValue.axis.y)*rotateSpeed;
                rotationToMake.y += -(m_rotateValue.axis.x) * rotateSpeed;
                hit.transform.gameObject.transform.rotation = Quaternion.Euler(rotationToMake.x+hit.transform.gameObject.transform.localEulerAngles.x, rotationToMake.y +hit.transform.gameObject.transform.localEulerAngles.y, 0);
            }
        }
    }
}
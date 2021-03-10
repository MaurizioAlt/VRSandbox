using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ObjectScaling : MonoBehaviour
{
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public SteamVR_Action_Boolean m_ScaleAction = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    public bool isScaling = false;
    public bool scalingLength = false;
    public bool scalingWidth = false;
    public bool scalingHeight = false;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    // Update is called once per frame
    void Update()
    {
        if(m_ScaleAction.GetState(m_Pose.inputSource) && isScaling)
        {
            scale();
        }
    }

    private void scale()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector2 delta;

        GameObject objectToScale;
        float scaleSpeed = .3f;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("InteractableObject"))
            {
                if (scalingWidth)
                {
                    Vector3 widthChange = new Vector3(0,0,0);
                    widthChange.x +=(m_MoveValue.axis.y)*scaleSpeed;
                    objectToScale = hit.transform.gameObject;
                    objectToScale.transform.localScale += (widthChange);
                }
                else if (scalingHeight)
                {

                    Vector3 heightChange = new Vector3(0, 0, 0);
                    heightChange.y += (m_MoveValue.axis.y)* scaleSpeed;
                    objectToScale = hit.transform.gameObject;
                    objectToScale.transform.localScale += heightChange;
                }
                else if (scalingLength)
                {
                    Vector3 lengthChange = new Vector3(0, 0, 0);
                    lengthChange.z += (m_MoveValue.axis.y) * scaleSpeed; 
                    objectToScale = hit.transform.gameObject;
                    objectToScale.transform.localScale += lengthChange;
                }
            }
        }
    }


}

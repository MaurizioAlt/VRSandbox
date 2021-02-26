using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotateObject : MonoBehaviour
{
    private bool m_HasPosition = false;
    public SteamVR_Action_Boolean m_RotateAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    public GameObject movePointer;
    private bool rotatingObj = false;

    public static InteractableObj m_CurrentInteractiable = null;
    public static List<InteractableObj> m_ContactInteractables = new List<InteractableObj>();

    // Start is called before th7e first frame update
    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
        m_Joint.connectedBody = movePointer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        m_HasPosition = UpdatePointer();
        movePointer.SetActive(m_HasPosition);

        if (rotatingObj)
        {
            m_CurrentInteractiable.transform.rotation = transform.rotation;
        }

        if (m_RotateAction.GetStateDown(m_Pose.inputSource))
        {
            beginRotation();
            Debug.Log("Up");

        }

        if (m_RotateAction.GetStateUp(m_Pose.inputSource))
        {
            endRotation();
            Debug.Log("Down");
        }
    }



    public void beginRotation()
    {
        //Get nearest itneractable
        m_CurrentInteractiable = GetNearestInteractable();

        //null check
        if (!m_CurrentInteractiable)
            return;

        //Already held check
      //  if (m_CurrentInteractiable.m_ActiveHand)
         //   m_CurrentInteractiable.m_ActiveHand.Drop();


        rotatingObj = true;
        movePointer.transform.parent = transform;

        //Attach
        //Rigidbody targetBody = m_CurrentInteractiable.GetComponent<Rigidbody>();

        //m_CurrentInteractiable.transform.parent = movePointer.transform;

        //m_Joint.connectedBody = targetBody;


        //Set active hand
       // m_CurrentInteractiable.m_ActiveHand = this;
    }

    public void endRotation()
    {
        //null check
        if (!m_CurrentInteractiable)
            return;

        //Apply velocity
        //Rigidbody targetBody = m_CurrentInteractiable.GetComponent<Rigidbody>();

        //Detach
        //m_Joint.connectedBody = null;
        //m_CurrentInteractiable.transform.parent = null;

        rotatingObj = false;
        movePointer.transform.parent = null;

        //Clear
      //  m_CurrentInteractiable.m_ActiveHand = null;
        m_CurrentInteractiable = null;
    }

    private InteractableObj GetNearestInteractable()
    {
        InteractableObj nearest = null;

        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (InteractableObj interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - movePointer.transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }

        }

        return nearest;
    }
    private bool UpdatePointer()
    {
        //Ray from controller
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //If its a hit
        if (Physics.Raycast(ray, out hit) && !rotatingObj)
        {
            movePointer.transform.position = hit.point;
            return true;
        }


        //If not a hit
        return false;
    }
}

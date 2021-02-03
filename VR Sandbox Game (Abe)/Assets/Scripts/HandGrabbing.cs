using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandGrabbing : MonoBehaviour
{

    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private InteractableObj m_CurrentInteractiable = null;
    private List<InteractableObj> m_ContactInteractables = new List<InteractableObj>();

    // Start is called before th7e first frame update
    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            Pickup();
            Debug.Log("Up");

        }

        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            Drop();
            Debug.Log("Down");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractableObject"))
            return;

        m_ContactInteractables.Add(other.gameObject.GetComponent<InteractableObj>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractableObject"))
            return;

        m_ContactInteractables.Remove(other.gameObject.GetComponent<InteractableObj>());
    }

    public void Pickup()
    {
        //Get nearest itneractable
        m_CurrentInteractiable = GetNearestInteractable();

        //null check
        if (!m_CurrentInteractiable)
            return;

        //Already held check
        if (m_CurrentInteractiable.m_ActiveHand)
            m_CurrentInteractiable.m_ActiveHand.Drop();

        //Position 
        m_CurrentInteractiable.transform.position = transform.position;

        //Attach
        Rigidbody targetBody = m_CurrentInteractiable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        //Set active hand
        m_CurrentInteractiable.m_ActiveHand = this;
    }

    public void Drop()
    {
        //null check
        if (!m_CurrentInteractiable)
            return;

        //Apply velocity
        Rigidbody targetBody = m_CurrentInteractiable.GetComponent<Rigidbody>();

        //Detach
        m_Joint.connectedBody = null;

        //Clear
        m_CurrentInteractiable.m_ActiveHand = null;
        m_CurrentInteractiable = null;
    }

    private InteractableObj GetNearestInteractable()
    {
        InteractableObj nearest = null;

        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(InteractableObj interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }

        }

        return nearest;
    }
}

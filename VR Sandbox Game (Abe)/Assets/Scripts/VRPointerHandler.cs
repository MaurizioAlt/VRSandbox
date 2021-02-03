using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR;

public class VRPointerHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public SteamVR_Action_Boolean m_MoveObject;

    private bool movingObject = false;

    private GameObject ObjectToMove;
    public GameObject m_Pointer;

    private SteamVR_Behaviour_Pose m_Pose = null;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
       // m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Update()
    {
        /*
        if (m_MoveObject.GetLastStateUp(m_Pose.inputSource))
        {
            laserPointer.PointerClick += PointerClick;
            movingObject = !movingObject;
        }

        if (movingObject)
        {
            ObjectToMove.transform.position = m_Pointer.transform.position;
        }
            
            */
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Sphere")
        {
            Debug.Log("Sphere was clicked");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
        }

        //Debug.Log("Eureka!");

        //ObjectToMove = e.target.transform.gameObject;
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Sphere")
        {
            Debug.Log("Sphere was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Sphere")
        {
            Debug.Log("Sphere was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
    }
}

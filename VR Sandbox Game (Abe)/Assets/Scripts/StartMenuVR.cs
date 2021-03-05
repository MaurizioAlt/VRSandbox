using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;
using System;
using UnityEngine.Events;

public class StartMenuVR : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    private SteamVR_Behaviour_Pose m_Pose = null;

    public Color32 hoverColor = Color.gray;

    // Start is called before the first frame update
    void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Menu"))
            {
                Debug.Log("hit Object");
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", hoverColor);
       
            }
        }
    }
}

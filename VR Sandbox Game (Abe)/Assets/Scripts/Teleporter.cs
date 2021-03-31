using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleporter : MonoBehaviour
{

    public GameObject m_Pointer;
    public SteamVR_Action_Boolean m_Teleportation;
    public AudioSource teleportSound;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool m_HasPosition = false;
    private bool m_IsTeleporting = false;
    private float m_FadeTime = .5f;

    public bool canTeleport = true;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Update()
    {
        //pointer
        m_HasPosition = UpdatePointer();
        m_Pointer.SetActive(m_HasPosition);

        //Teleport
        if (m_Teleportation.GetLastStateUp(m_Pose.inputSource) &&  canTeleport)
            TryToTeleport();

    }

    private void TryToTeleport()
    {
        //check for valid position and if already teleporting
        if (!m_HasPosition|| m_IsTeleporting)
        {
            return;
        }

        //Get Camera rig and head position
        Transform cameraRig = SteamVR_Render.Top().origin;
        Vector3 headPosition = SteamVR_Render.Top().head.position;

        //Figure out translation
        Vector3 groundPosition = new Vector3(headPosition.x, cameraRig.position.y, headPosition.z);
        Vector3 translateVector = m_Pointer.transform.position - groundPosition;

        //Move
        StartCoroutine(MoveRig(cameraRig, translateVector));
        teleportSound.Play();
    }

    private IEnumerator MoveRig(Transform cameraRig, Vector3 translation)
    {
        //flag 
        m_IsTeleporting = true;

        //fade to black
        SteamVR_Fade.Start(Color.black, m_FadeTime, true);

        //apply translation
        yield return new WaitForSeconds(m_FadeTime);
        cameraRig.position += translation;

        //fade back to clear
        SteamVR_Fade.Start(Color.clear, m_FadeTime, true);

        //De-flag
        m_IsTeleporting = false;

    }

    private bool UpdatePointer()
    {
        //Ray from controller
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //If its a hit
        if(Physics.Raycast(ray, out hit))
        {
            m_Pointer.transform.position = hit.point;
            return true;
        }
            

        //If not a hit
        return false;
    }
}

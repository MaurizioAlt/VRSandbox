using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR;

public class CopyPaste : MonoBehaviour
{
    public bool isCopyingObject =  false;
    public bool isPastingObject = false;
    public GameObject copyObject;
    private GameObject objToDisplay;
    private Spawner spawnerScript;
    private Vector3 objectDisplayPosition = new Vector3(0, -58, -13);

    public SteamVR_Action_Boolean m_copyAction = null;
    public SteamVR_Action_Boolean m_pasteAction = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    public GameObject copiedDisplayPanel;
    public AudioSource copySound;
    Collider displayObjectCollider;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        spawnerScript = GameObject.FindGameObjectWithTag("RightControl").GetComponent<Spawner>();
    }

    void Update()
    {
        if (isCopyingObject)
        {
            Copy();
        }
        if(isPastingObject && copyObject != null && (m_pasteAction.GetStateDown(m_Pose.inputSource))){
            Paste();
        }

    }
    public void Copy()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector2 delta;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("InteractableObject"))
            {
                if (m_copyAction.GetStateDown(m_Pose.inputSource)){
                    copyObject = hit.collider.gameObject;
                    

                    copySound.Play();
                }
            }
        }
}
    public void Paste()
    {
        spawnerScript.spawnDupe(copyObject);
    }
}

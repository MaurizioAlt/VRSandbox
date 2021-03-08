using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


    public class Spawner : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject spawnmenu;
    public GameObject[] spawnObjects;
    private int index;
    public GameObject m_Pointer;
    public bool spawningObject = false;
    public int objectToSpawn;
    public bool deletingObject = false;
    


    public SteamVR_Action_Boolean m_SpawnObject;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool m_HasPosition = false;

    // forward spawning distance based on camera
    public int forwardDistance = 5;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    
    private void Update()
    {
        //pointer
        m_HasPosition = UpdatePointer();
        m_Pointer.SetActive(m_HasPosition);


        //spawn object
        if (m_SpawnObject.GetLastStateUp(m_Pose.inputSource) && spawningObject) {
            spawn();
        }
        


    }

   
    public void spawn()
    {
        Debug.Log("Tried spawning object");
        Vector3 pointerPosition = new Vector3(m_Pointer.transform.position.x, m_Pointer.transform.position.y+(spawnObjects[0].transform.localScale.y)/2, m_Pointer.transform.position.z);

        Instantiate(spawnObjects[objectToSpawn], pointerPosition, m_Pointer.transform.rotation);
    }

    public void setIndex(int i)
    {
        index = i;
    }

    public void EnterMainMenu()
    {
        mainmenu.SetActive(true);
    }

    public void SwitchMainToSpawn()
    {
        mainmenu.SetActive(false);
        spawnmenu.SetActive(true);
    }

    public void SwitchSpawnToMain()
    {
        mainmenu.SetActive(true);
        spawnmenu.SetActive(false);
    }

    private bool UpdatePointer()
    {
        //Ray from controller
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //If its a hit
        if (Physics.Raycast(ray, out hit))
        {
            m_Pointer.transform.position = hit.point;
            return true;
        }


        //If not a hit
        return false;
    }
}

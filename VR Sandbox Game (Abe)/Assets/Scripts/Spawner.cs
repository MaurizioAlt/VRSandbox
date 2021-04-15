using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


    public class Spawner : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject spawnmenu;
    public GameObject[] spawnObjects;
    public static GameObject[] spawnableObjects;
    private int index;
    public GameObject m_Pointer;
    public bool spawningObject = false;
    public int objectToSpawn;
    public bool deletingObject = false;
    public AudioSource spawnSound;
    public AudioSource deleteSound;

    private bool objListInitialized = false;


    public SteamVR_Action_Boolean m_SpawnObject;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool m_HasPosition = false;

    // forward spawning distance based on camera
    public int forwardDistance = 5;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        spawnableObjects = spawnObjects;
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
        if (m_SpawnObject.GetStateDown(m_Pose.inputSource) && deletingObject)
        {
            delete();
        }


    }

    public void delete()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector2 delta;

        Debug.Log("Deleting");

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("InteractableObject") && (m_SpawnObject.GetStateDown(m_Pose.inputSource)))
            {
                Object.Destroy(hit.transform.gameObject);
                deleteSound.Play();
            }

        }
    }

    public void spawn()
    {
        Debug.Log("Tried spawning object");

        float heightMult = 1;
        if(objectToSpawn == 10)
        {
            heightMult = 3f;
        }
        else
        {
            heightMult = 1;
        }
        Vector3 pointerPosition = new Vector3(m_Pointer.transform.position.x, m_Pointer.transform.position.y+(spawnObjects[objectToSpawn].transform.localScale.y * heightMult), m_Pointer.transform.position.z);

        spawnSound.Play();

        Instantiate(spawnObjects[objectToSpawn], pointerPosition, m_Pointer.transform.rotation);
    }

    public void spawnDupe(GameObject dupeToSpawn)
    {
        Vector3 pointerPosition = new Vector3(m_Pointer.transform.position.x, m_Pointer.transform.position.y + (dupeToSpawn.transform.localScale.y), m_Pointer.transform.position.z);
        spawnSound.Play();
        Instantiate(dupeToSpawn, pointerPosition, dupeToSpawn.transform.rotation);
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

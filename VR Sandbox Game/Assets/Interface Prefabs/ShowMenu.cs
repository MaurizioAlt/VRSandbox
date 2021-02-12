using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.Extras;

public class ShowMenu : MonoBehaviour
{
    public GameObject VRMenu;
    // Start is called before the first frame update
    void Awake()
    {
        VRMenu.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

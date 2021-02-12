using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject spawnmenu;
    public GameObject loadmenu;
    public GameObject savemenu;
    public GameObject[] spawnObjects;
    
    // forward spawning distance based on camera
    public int forwardDistance = 5;

    public void spawn(int i)
    {
        Instantiate(spawnObjects[i], Camera.main.transform.position + Camera.main.transform.forward * forwardDistance, Camera.main.transform.rotation);
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

    public void SwitchMainToLoad()
    {
        mainmenu.SetActive(false);
        loadmenu.SetActive(true);
    }

    public void SwitchloadToMain()
    {
        mainmenu.SetActive(true);
        loadmenu.SetActive(false);
    }
    public void SwitchMainToSave()
    {
        mainmenu.SetActive(false);
        savemenu.SetActive(true);
    }

    public void SwitchsaveToMain()
    {
        mainmenu.SetActive(true);
        savemenu.SetActive(false);
    }
}

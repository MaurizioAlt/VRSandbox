using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject spawnmenu;
    public static GameObject[] spawnObjects;
    
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

    public static GameObject GetSpawnObject(int index)
    {
        return index < spawnObjects.Length ?
            spawnObjects[index] : null;
    }
}

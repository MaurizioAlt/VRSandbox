using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    
    // forward spawning distance based on camera
    public int forwardDistance = 5;

    public void spawn(int i)
    {
        Instantiate(spawnObjects[i], Camera.main.transform.position + Camera.main.transform.forward * forwardDistance, Camera.main.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static Dictionary<string, int> objects = new Dictionary<string, int>();
    public static GameObject[] objListSpawnable;


    public static void createObjList(GameObject[] spawnObjects)
    {
        Debug.Log("Creating objList");
        objListSpawnable = new GameObject[spawnObjects.Length];
        // add name of objects that going to be spawned
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            if (!ObjectList.objects.ContainsKey(spawnObjects[i].name)){
                ObjectList.objects.Add(spawnObjects[i].name, i);
                objListSpawnable[i] = spawnObjects[i];
            }
            if(objListSpawnable[i] == null)
            {
                Debug.Log("obj is null");
            }
        }
        Debug.Log(objListSpawnable.Length);
    }
}

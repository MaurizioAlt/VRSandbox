using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static HashSet<string> objects = new HashSet<string>();

    public static void PrintList()
    {
        Debug.Log("ObjectList: " + "size: " + objects.Count);
        foreach (string obj in objects)
        {
            Debug.Log(obj + " ");
        }
    }
}

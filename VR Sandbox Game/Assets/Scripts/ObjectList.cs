using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static Dictionary<string, int> objects = new Dictionary<string, int>();

    public static void PrintList()
    {
        Debug.Log("ObjectList: " + "size: " + objects.Count);
        foreach (KeyValuePair<string, int> entry in objects)
        {
            Debug.Log(entry.Key + ":  " + entry.Value);
        }
    }
}

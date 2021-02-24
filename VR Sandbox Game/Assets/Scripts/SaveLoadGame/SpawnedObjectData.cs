using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
// public enum ObjectType
// {
//     Sphere,
//     Cube,
//     Prism,
//     Capsule,
//     Cylinder
// }

[System.Serializable]
public class SpanwedObjectData
{
    public string id;

    // public ObjectType objectType;

    public Vector3 position;

    public Quaternion rotation; 

    public static List<SpanwedObjectData> GetObjectData(List<GameObject> objList)
    {
        List<SpanwedObjectData> list = new List<SpanwedObjectData>();;
        foreach (GameObject obj in objList)
        {
            
        }

        return list; 
    }
}
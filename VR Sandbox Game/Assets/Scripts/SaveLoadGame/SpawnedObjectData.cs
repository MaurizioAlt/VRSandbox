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
public class SpawnedObjectData
{
    public int id;

    public string name;

    // public ObjectType objectType;

    public Vector3 position;

    public Quaternion rotation; 

    public Color color;

    public static List<SpawnedObjectData> GetSpawnedObjectData(List<GameObject> objList)
    {
        List<SpawnedObjectData> list = new List<SpawnedObjectData>();;
        foreach (GameObject obj in objList)
        {
            SpawnedObjectData curr = new SpawnedObjectData();
            bool res = ObjectList.objects.TryGetValue(obj.name, out curr.id);
            if(!res) { Debug.Log("SpawnedObjectData >>> GetObjectData >>> unknow object name: " + obj.name); }
            curr.position = obj.transform.position;
            curr.rotation = obj.transform.rotation;
            curr.color = obj.GetComponent<Renderer>().material.color;
            curr.name = obj.name;
            list.Add(curr);
            Debug.Log("SpawnedObjectData >>> GetObjectData >>> added object: " + curr.name + ", id: " + curr.id + ", pos: " + curr.position + ", rot: " + curr.rotation);
        }

        return list; 
    }
}
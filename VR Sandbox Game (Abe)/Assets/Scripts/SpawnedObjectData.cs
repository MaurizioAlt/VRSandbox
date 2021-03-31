using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnedObjectData
{
    public int id;

    public string name;

    public Vector3 position;

    public Vector3 scale;

    public Quaternion rotation; 

    public Color color;

    public static List<SpawnedObjectData> GetSpawnedObjectData(List<GameObject> objList)
    {
        List<SpawnedObjectData> list = new List<SpawnedObjectData>();;
        foreach (GameObject obj in objList)
        {
            SpawnedObjectData curr = new SpawnedObjectData();
            string name = obj.name;
            if(obj.name.IndexOf("(Clone)") != obj.name.LastIndexOf("(Clone)"))
            {
                name = obj.name.Substring(0, obj.name.IndexOf("(Clone)") + 7);
            }
            //bool res = ObjectList.objects.TryGetValue(name, out curr.id);

            //if(!res) { Debug.Log("SpawnedObjectData >>> GetObjectData >>> unknow object name: " + obj.name); }
            curr.position = obj.transform.position;
            curr.rotation = obj.transform.rotation;
            curr.color = obj.GetComponent<Renderer>().material.color;
            curr.name = obj.name;
            curr.scale = obj.transform.localScale;
            list.Add(curr);
            Debug.Log("SpawnedObjectData >>> GetObjectData >>> added object: " + curr.name + ", id: " + curr.id + ", pos: " + curr.position + ", rot: " + curr.rotation);
        }

        return list; 
    }
}
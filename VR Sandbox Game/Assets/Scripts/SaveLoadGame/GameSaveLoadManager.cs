using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveLoadManager : MonoBehaviour
{
    private bool isDebug = true;
    public void Load()
    {   
        // grab all the spawned objects from the hierarchy
        if(isDebug) Debug.Log("GameSaveLoadManager >>> Load()");
        if(isDebug) ObjectList.PrintList();
        List<GameObject> objList = GetSpanwedObjects();
        List<SpanwedObjectData> objData = SpanwedObjectData.GetObjectData(objList);
    }

    public void Save() 
    {

    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        SurrogateSelector selector = new SurrogateSelector();

        Vector3SerializationSurrogate v3s = new Vector3SerializationSurrogate();
        QuaternionSerializationSurrogate qs = new QuaternionSerializationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3s);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qs);

        formatter.SurrogateSelector = selector;

        return formatter;
    }

    public List<GameObject> GetSpanwedObjects()
    {
        List<GameObject> gameObjects = new List<GameObject>();
        int i = 0;
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if(ObjectList.objects.Contains(obj.name)) 
            {
                if(isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() number "  + i++ + " : " + obj.name);
            }
        }
        if(isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() >>> # objects detected: " + i);
        return gameObjects;
    }
}

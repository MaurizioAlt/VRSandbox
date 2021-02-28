using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveLoadManager : MonoBehaviour
{
    private bool isDebug = true;
    public void Save()
    {   
        if(isDebug) Debug.Log("GameSaveLoadManager >>> Load()");
        if(isDebug) ObjectList.PrintList();

        // grab all the spawned objects from the hierarchy
        List<GameObject> objList = GetSpanwedObjects();

        // put in a wrapper class and tell SpawnedObjectSaveData
        List<SpawnedObjectData> objData = SpawnedObjectData.GetSpawnedObjectData(objList);
        SpawnedObjectSaveData.current.spawnedObjects = objData;
        SpawnedObjectSaveData.current.PrintSpawnedObjects();
        SaveSpanwedObjectData("savegame_test");
    }

    public void SaveSpanwedObjectData(string saveName)
    {

        BinaryFormatter formatter = GetBinaryFormatter();
        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves" + saveName + ".save";

        FileStream file = File.Create(path);

        formatter.Serialize(file, SpawnedObjectSaveData.current.spawnedObjects);

        Debug.Log("GameSaveLoadManager >>> SaveSpanwedObjectData >>> path: " + path);
    }

    public void Load() 
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
            if(ObjectList.objects.ContainsKey(obj.name)) 
            {
                if(isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() number "  + i++ + " : " + obj.name);
                gameObjects.Add(obj);
            }
        }
        if(isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() >>> # objects detected: " + i);
        return gameObjects;
    }
}

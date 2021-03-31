using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveLoadManage : MonoBehaviour
{
    private bool isDebug = true;
    private string path;
    private string saveName;

    public Spawner spawner;

    public void Start()
    {
        //saveName = "savegame_test";
        //path = Application.persistentDataPath + "/saves/" + saveName + ".save";
    }

    // call by the user, pass in saveName if want the user able to save different files
    public void Save(string saveName)
    {

        if (isDebug) Debug.Log("GameSaveLoadManager >>> Load()");
        // if(isDebug) ObjectList.PrintList();
        //saveName = "savegame_test";
        path = Application.persistentDataPath + "/saves/" + saveName + ".save";
        SaveObjects();

        // save the path, change if want multi file saving
        path = SaveSpanwedObjectData(saveName);
    }



    public string SaveSpanwedObjectData(string fileName)
    {

        BinaryFormatter formatter = GetBinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves/" + fileName + ".save";

        FileStream file = File.Create(path);

        formatter.Serialize(file, (object)SpawnedObjectSaveData.current);

        Debug.Log("GameSaveLoadManager >>> SaveSpanwedObjectData >>> path: " + path);

        file.Close();

        return path;
    }

    // call by user, pass in fileName if want user able to save different files
    // and change saveName to fileName for the path variable
    public void Load(String fileName)
    {
        DestroyAllSpawnedObjectOnScene();

        Debug.Log("GameSaveLoadManager >>> Load()");
        if (!File.Exists(path))
        {
            SpawnedObjectSaveData.current = null;
            return;
        }

        path = Application.persistentDataPath + "/saves/" + fileName + ".save";

        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            SpawnedObjectSaveData.current = (SpawnedObjectSaveData)save;
            Debug.Log("GameSaveLoadManager >>> Load(), spanwedobject count: " + SpawnedObjectSaveData.current.spawnedObjects.Count);
            InitializeObjects();
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("GameSaveLoadManager >>> Failed to load file at {0}, {1}", path, e);
            file.Close();
            SpawnedObjectSaveData.current = null;
            return;
        }

    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        SurrogateSelector selector = new SurrogateSelector();

        Vector3SerializationSurrogate v3s = new Vector3SerializationSurrogate();
        QuaternionSerializationSurrogate qs = new QuaternionSerializationSurrogate();
        ColorSerializationSurrogate color = new ColorSerializationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3s);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qs);
        selector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), color);

        formatter.SurrogateSelector = selector;

        return formatter;
    }

    public void InitializeObjects()
    {
        for (int i = 0; i < SpawnedObjectSaveData.current.spawnedObjects.Count; i++)
        {
            SpawnedObjectData currentObj = SpawnedObjectSaveData.current.spawnedObjects[i];

            // This might be a problem depending on how we are instantiating the objects
            GameObject spawnedObj = Instantiate(spawner.spawnObjects[currentObj.id], currentObj.position, currentObj.rotation);
            spawnedObj.GetComponent<Renderer>().material.color = currentObj.color;
            spawnedObj.transform.localScale = currentObj.scale;
        }
    }

    public void DestroyAllSpawnedObjectOnScene()
    {
        List<GameObject> objs = GetSpanwedObjects();
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
    }

    public List<GameObject> GetSpanwedObjects()
    {


        List<GameObject> gameObjects = new List<GameObject>();
        int i = 0;
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            // can be changed to tag checking instead of checking for (clone)
            if (obj.name.Contains("(Clone)"))
            {
                if (isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() number " + i++ + " : " + obj.name);
                gameObjects.Add(obj);
            }
        }
        if (isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() >>> # objects detected: " + i);
        return gameObjects;
    }
    public void SaveObjects()
    {
        // grab all the spawned objects from the hierarchy
        List<GameObject> objList = GetSpanwedObjects();
        Debug.Log(objList);
        // put in a wrapper class and tell SpawnedObjectSaveData
        List<SpawnedObjectData> objData = SpawnedObjectData.GetSpawnedObjectData(objList);
        SpawnedObjectSaveData.current.spawnedObjects = objData;
        SpawnedObjectSaveData.current.PrintSpawnedObjects();
    }


}

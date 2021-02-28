﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveLoadManager : MonoBehaviour
{
    private bool isDebug = true;
    private string path;

    public Spawner spawner;

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
        path = SaveSpanwedObjectData("savegame_test");
    }

    public string SaveSpanwedObjectData(string saveName)
    {

        BinaryFormatter formatter = GetBinaryFormatter();
        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves" + saveName + ".save";

        FileStream file = File.Create(path);

        formatter.Serialize(file, (object)SpawnedObjectSaveData.current);

        Debug.Log("GameSaveLoadManager >>> SaveSpanwedObjectData >>> path: " + path);
        
        file.Close();

        return path;
    }

    public void Load() 
    {
        DestroyAllSpawnedObjectOnScene();

        Debug.Log("GameSaveLoadManager >>> Load()");
        if(!File.Exists(path))
        {
            SpawnedObjectSaveData.current = null;
            return;
        }
        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            SpawnedObjectSaveData.current = (SpawnedObjectSaveData)save;
            Debug.Log("GameSaveLoadManager >>> Load(), spanwedobject count: " + SpawnedObjectSaveData.current.spawnedObjects.Count);
            LoadObjects();
        }
        catch(Exception e)
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

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3s);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qs);

        formatter.SurrogateSelector = selector;

        return formatter;
    }

    public void LoadObjects()
    {
        for(int i = 0; i < SpawnedObjectSaveData.current.spawnedObjects.Count; i++)
        {
            SpawnedObjectData currentObj = SpawnedObjectSaveData.current.spawnedObjects[i];
            Instantiate(spawner.spawnObjects[i], currentObj.position, currentObj.rotation);

        }
    }

    public void DestroyAllSpawnedObjectOnScene()
    {
        List<GameObject> objs = GetSpanwedObjects();
        foreach(GameObject obj in objs)
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
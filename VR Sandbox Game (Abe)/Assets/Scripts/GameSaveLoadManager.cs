using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveLoadManager : MonoBehaviour
{
    private bool isDebug = true;
    private string path;
    private string saveName;


    public void Awake()
    {
        
    }
    public void Start()
    {
        saveName = "savegame_test";
        path = Application.persistentDataPath + "/saves/" + saveName + ".save";
    }

    // call by the user, pass in saveName if want the user able to save different files
    public void Save(string saveName)
    {   
        if(isDebug) Debug.Log("GameSaveLoadManager >>> Save()");
        //if(isDebug) ObjectList.PrintList();

        // grab all the spawned objects from the hierarchy
        List<GameObject> objList = GetSpanwedObjects();

        //Saving index of current scene
        SpawnedObjectSaveData.current.sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // put in a wrapper class and tell SpawnedObjectSaveData
        List<SpawnedObjectData> objData = SpawnedObjectData.GetSpawnedObjectData(objList);
        SpawnedObjectSaveData.current.spawnedObjects = objData;
        SpawnedObjectSaveData.current.PrintSpawnedObjects();

        // save the path, change if want multi file saving
        path = SaveSpanwedObjectData(saveName);
    }

    public string SaveSpanwedObjectData(string fileName)
    {

        BinaryFormatter formatter = GetBinaryFormatter();
        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
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
    public void Load(string saveName) 
    {
        DestroyAllSpawnedObjectOnScene();

        Debug.Log("GameSaveLoadManager >>> Load()");

        path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        if (!File.Exists(path))
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

            if(SceneManager.GetActiveScene().buildIndex != SpawnedObjectSaveData.current.sceneIndex)
                SceneManager.LoadScene(SpawnedObjectSaveData.current.sceneIndex);

                Debug.Log("GameSaveLoadManager >>> Load(), spanwedobject count: " + SpawnedObjectSaveData.current.spawnedObjects.Count);
            InitializeObjects();
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
        ColorSerializationSurrogate color = new ColorSerializationSurrogate();

        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3s);
        selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qs);
        selector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), color);

        formatter.SurrogateSelector = selector;

        return formatter;
    }

    public void InitializeObjects()
    {
        Debug.Log("Objects initialize");
        for(int i = 0; i < SpawnedObjectSaveData.current.spawnedObjects.Count; i++)
        {
            SpawnedObjectData currentObj = SpawnedObjectSaveData.current.spawnedObjects[i];

            GameObject spawnedObj = Instantiate(Spawner.spawnableObjects[currentObj.id], currentObj.position, currentObj.rotation);
            spawnedObj.GetComponent<Renderer>().material.color = currentObj.color;
            spawnedObj.transform.localScale = currentObj.scale;
            
         
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
            // ObjectList.objects.ContainsKey(obj.name)
            // filter out the non interactable object for user
            if(obj.CompareTag("InteractableObject") )
            {
                if(isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() number "  + i++ + " : " + obj.name);
                gameObjects.Add(obj);
            }
        }
        if(isDebug) Debug.Log("GameSaveLoadManager >>> GetSpanwedObjects() >>> # objects detected: " + i);
        return gameObjects;
    }


}

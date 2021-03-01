using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnedObjectSaveData 
{
    private static SpawnedObjectSaveData _current;
    public static SpawnedObjectSaveData current
    {
        get
        {
            if(_current == null)
            {
                _current = new SpawnedObjectSaveData();
            }

            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }

    public static void OnSave()
    {
        SerialManager.Save("objectsave", SpawnedObjectSaveData.current);
    }

    public List<SpawnedObjectData> spawnedObjects;

    public void PrintSpawnedObjects()
    {
        foreach(SpawnedObjectData data in spawnedObjects)
        {
            Debug.Log("SpanwedObjectSaveData >>> PrintSpanwedObjects" + data.name + ", id: " + data.id + ", pos: " + data.position + ", rot: " + data.rotation);
        }
    }

}
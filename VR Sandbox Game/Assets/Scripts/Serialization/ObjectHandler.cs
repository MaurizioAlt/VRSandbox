using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public ObjectType objectType;

    public ObjectData objectData;

    public void Start()
    {
        if(string.IsNullOrEmpty(objectData.id))
        {
            objectData.id = System.DateTime.Now.ToLongDateString() + System.DateTime.Now.ToLongTimeString() + Random.Range(0, int.MaxValue).ToString();
            objectData.objectType = objectType;
            SaveData.current.objectOne.Add(objectData);
        }

        //GameEvents
    }

    private void Update()
    {
        objectData.position = transform.position;
        objectData.rotation = transform.rotation;
    }

    void DestroyMe()
    {
        //Gameevent
        Destroy(gameObject);
    }

    public void Save()
    {
        SaveData.OnSave();
    }
    public void Load()
    {
        SaveData.OnLoad();
    }

}

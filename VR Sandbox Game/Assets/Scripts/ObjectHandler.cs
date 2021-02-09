using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public int objectid;

    public ObjectData objectData;

    public void Start()
    {
        if(string.IsNullOrEmpty(objectData.id))
        {
            objectData.id = System.DateTime.Now.ToLongDateString() + 
                    System.DateTime.Now.ToLongTimeString() + 
                    Random.Range(0, int.MaxValue).ToString();
            objectData.objectid = objectid;
            // here add
            // SaveData.current.objects.Add(objectData)
        }
        GameEvents.current.onLoadEvent += DestroyObject;
    }

    private void Update()
    {
        objectData.position = transform.position;
        objectData.rotation = transform.rotation;
    }

    void DestroyObject()
    {
        GameEvents.current.onLoadEvent -= DestroyObject;
        Destroy(gameObject);
    }
}

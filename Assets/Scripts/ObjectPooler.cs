using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    //public GameObject secondObjectToPool;
    public int amountToPool;

    // called as soon as the object is created
    void Awake()
    {
        SharedInstance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pooledObjects = new List<GameObject>();
        // Loop through list of pooled objects, deactiving them and adding them to the list
        for ( int i =0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject) Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject()
    {
        // for aas many object as are in the pooledObjects
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) // if the pooledObject is Not active, return that object
                return pooledObjects[i];
        } 
        return null; // otherwise return null
    }
}

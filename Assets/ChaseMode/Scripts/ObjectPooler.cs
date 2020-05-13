using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;



    // Start is called before the first frame update
    // create a list of game objects and loop from 0 to pooled amount,
    // every increment instantiate a new game object, set it to inactive and add it to the list
    void Start()
    {
        
        pooledObjects = new List<GameObject>();

        
        for (int i = 0; i < pooledAmount; i++) {

            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // loop through the list of pooledObjects, if you find an inactive object within the list return it
    // if there is no inactive game object in the list then create a new one,
    // set it to inactive, add it to the list of pooledObjects, then return it.
    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < pooledObjects.Count; i++) {
            
            if (!pooledObjects[i].activeInHierarchy) {

                return pooledObjects[i];
            }


        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;


    }
}

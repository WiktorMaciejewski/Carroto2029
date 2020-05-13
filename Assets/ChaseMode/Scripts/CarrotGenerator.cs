using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGenerator : MonoBehaviour
{

    public ObjectPooler carrotPool;

    public float distanceBetweenCarrots;

    // retrieve 3 game objects from carrotPool, assign them to carrot1, 2 and 3, 
    // position one in the startPosition passed through, one to the left of that position and one to the right
    // then make them active within the scene
    public void SpawnCarrots(Vector3 startPosition) {
        
        GameObject carrot1 = carrotPool.GetPooledObject();
         
        carrot1.transform.position = startPosition;
        
        carrot1.SetActive(true);

        
        GameObject carrot2 = carrotPool.GetPooledObject();
        
        carrot2.transform.position = new Vector3(startPosition.x - distanceBetweenCarrots, startPosition.y, startPosition.z);
        carrot2.SetActive(true);

        
        GameObject carrot3 = carrotPool.GetPooledObject();
        
        carrot3.transform.position = new Vector3(startPosition.x + distanceBetweenCarrots, startPosition.y, startPosition.z);
        carrot3.SetActive(true);


    }
}
